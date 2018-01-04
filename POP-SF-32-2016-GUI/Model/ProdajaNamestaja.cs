using POP_SF_32_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF32_2016.Model
{
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }


        private DateTime datumProdaje;

        public DateTime DatumProdaje
        {
            get
            {
                return datumProdaje;
            }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        private string brojRacuna;

        public string BrojRacuna
        {
            get
            {
                return brojRacuna;
            }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        private string kupac;

        public string Kupac
        {
            get
            {
                return kupac;
            }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        private const double pdv = 0.2;


        public  double PDV
        {
            get
            {
                return pdv;
            }
            set
            {
                //pdv = 0.2;
                OnPropertyChanged("PDV");
            }
        }
        
        private double ukupanIznos;
    
        public double UkupanIznos
        {
            get
            {
                var listaNamestaja = Projekat.Instance.Namestaji;
                var listaUsluga = Projekat.Instance.DodatnaUsluge;
                foreach (var namestaj in listaNamestaja)
                {
                    foreach (var usluga in listaUsluga)
                    {
                        ukupanIznos = namestaj.JedinicnaCena * namestaj.KolicinaUMagacinu + usluga.Cena;
                    }
                }
                return ukupanIznos;
            }
            set
            {
                ukupanIznos = value;
                OnPropertyChanged("UkupanIznos");
            }
        }


        private double ukupanIznosPdv;

        public double UkupanIznosPDV
        {
            get
            {
                var listaNamestaja = Projekat.Instance.Namestaji;
                var listaUsluga = Projekat.Instance.DodatnaUsluge;

                foreach (var namestaj in listaNamestaja)
                {
                    foreach (var usluga in listaUsluga)
                    {
                        ukupanIznos = (namestaj.JedinicnaCena * namestaj.KolicinaUMagacinu + usluga.Cena) * pdv;
                    }
                }

                return ukupanIznosPdv;
            }
            set {
                ukupanIznosPdv = value;
                OnPropertyChanged("UkupanIznosPDV");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{DatumProdaje}, {BrojRacuna}, {Kupac}, {UkupanIznos}";
        }

        public static ProdajaNamestaja GetById(int id)
        {
            foreach (var prodaja in Projekat.Instance.ProdajeNamestaja)
            {
                if (prodaja.Id == id)
                {
                    return prodaja;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                Id = id,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                PDV = pdv,
                UkupanIznos = ukupanIznos
            };
        }

        #region CRUD
        public static ObservableCollection<ProdajaNamestaja> GetAll()
        {
            var prodaja = new ObservableCollection<ProdajaNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM ProdajaNamestaja;";
                da.SelectCommand = cmd;
                da.Fill(ds, "ProdajaNamestaja");

                foreach (DataRow row in ds.Tables["ProdajaNamestaja"].Rows)
                {
                    var p = new ProdajaNamestaja();
                    p.Id = int.Parse(row["Id"].ToString());
                    p.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());
                    p.BrojRacuna = row["BrojRacuna"].ToString();
                    p.Kupac = row["Kupac"].ToString();
                    p.UkupanIznos = double.Parse(row["UkupanIznos"].ToString());


                    prodaja.Add(p);
                }

            }


            return prodaja;
        }
        #endregion

        #region CRUD
        public static ProdajaNamestaja Create(ProdajaNamestaja p)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "INSERT INTO ProdajaNamestaja (DatumProdaje, BrojRacuna, Kupac, UkupanIznos) VALUES (@DatumProdaje, @BrojRacuna, @Kupac, @UkupanIznos);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DatumProdaje", p.DatumProdaje);
                cmd.Parameters.AddWithValue("Kupac", p.Kupac);
                cmd.Parameters.AddWithValue("BrojRacuna", p.BrojRacuna);
                cmd.Parameters.AddWithValue("UkupanIznos", p.UkupanIznos);
                
                p.Id = int.Parse(cmd.ExecuteScalar().ToString());

                var listaNamestaja = Projekat.Instance.StavkeNamestaja;
           

                //for (int i = 0; i < listaNamestaja.Count; i++)
                foreach (var namestaj in listaNamestaja)
                {
                    SqlCommand command = con.CreateCommand();
                  
                    command.CommandText = "INSERT INTO StavkeNamestaja (IdProdaje, NamestajId, Kolicina) VALUES (@IdProdaje, @NamestajId, @Kolicina);";
                    command.Parameters.AddWithValue("IdProdaje", p.Id);
                    command.Parameters.AddWithValue("NamestajId", namestaj.NamestajId);
                    command.Parameters.AddWithValue("Kolicina", namestaj.KolicinaNamestaja);

                    command.ExecuteScalar();

                }

                var listaUsluga = Projekat.Instance.StavkeUsluge;
                //for (int i = 0; i < listaUsluga.Count; i++)
                foreach (var usluga in listaUsluga)
                {
                    SqlCommand command = con.CreateCommand();

                    command.CommandText = "INSERT INTO StavkeUsluge (IdProdaje, UslugaId) VALUES (@IdProdaje, @UslugaId);";
                    command.Parameters.AddWithValue("IdProdaje", p.Id);
                    command.Parameters.AddWithValue("UslugaId", usluga.UslugaId);

                    command.ExecuteScalar();
                }
            }

            Projekat.Instance.ProdajeNamestaja.Add(p);

            return p;
        }
        #endregion

        #region CRUD
        public static void Update(ProdajaNamestaja p)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "UPDATE ProdajaNamestaja SET DatumProdaje=@DatumProdaje, BrojRacuna=@BrojRacuna, Kupac=@Kupac, Kolicina=@Kolicina WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", p.Id);
                cmd.Parameters.AddWithValue("DatumProdaje", p.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", p.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", p.Kupac);

                cmd.ExecuteNonQuery();
            }

            foreach (var prodaja in Projekat.Instance.ProdajeNamestaja)
            {
                if (p.Id == prodaja.Id)
                {
                    prodaja.DatumProdaje = p.DatumProdaje;
                    prodaja.BrojRacuna = p.BrojRacuna;
                    prodaja.Kupac = p.Kupac;
                }
            }
        }

        #endregion
    }
}
