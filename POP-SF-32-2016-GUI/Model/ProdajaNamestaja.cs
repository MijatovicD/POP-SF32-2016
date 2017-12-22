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

        //private int namestajId;

        //public int NamestajId
        //{
        //    get
        //    {
        //        return namestajId;
        //    }
        //    set
        //    {
        //        namestajId = value;
        //        OnPropertyChanged("NamestajId");
        //    }
        //}

        private ObservableCollection<StavkaNamestaja> Stavkaprodaje;

        public ObservableCollection<StavkaNamestaja> StavkaProdaje
        {
            get
            {
                return Stavkaprodaje;
            }
            set
            {
                Stavkaprodaje = value;
            }
        }

        //private StavkaProdaje stavkaProdaje;
        //private int stavkaProdajeId;
        //public int StavkaProdajeId
        //{
        //    get
        //    {
        //        return stavkaProdajeId;
        //    }
        //    set
        //    {
        //        StavkaProdajeId = value;
        //        OnPropertyChanged("StavkaProdajeId");
        //    }
        //}

        //[XmlIgnore]
        //public StavkaProdaje stavka
        //{
        //    get
        //    {
        //        if (stavkaProdaje == null)
        //        {
        //            stavkaProdaje = stavka.GetById(StavkaProdajeId);
        //        }
        //        return stavkaProdaje;
        //    }
        //    set
        //    {
        //        stavkaProdaje = value;
        //        StavkaProdajeId = stavkaProdaje.Id;
        //        OnPropertyChanged("StavkaProdaje");
        //    }
        //}

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

        private int dodatnaUslugaId;
        public int DodatnaUslugaId
        {
            get
            {
                return dodatnaUslugaId;
            }
            set
            {
                dodatnaUslugaId = value;
                OnPropertyChanged("DodatnaUslugaId");
            }
        }

        private int namestajId;

        public int NamestajaId
        {
            get
            {
                return namestajId;
            }
            set
            {
                namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }


        private const double pdv = 0.02;

        public  double PDV
        {
            get
            {
                return pdv;
            }
            set
            {
                //pdv = 0.02;
                OnPropertyChanged("PDV");
            }
        }

        private double ukupanIznos;

        public double UkupanIznos
        {
            get
            {
                return ukupanIznos;
            }
            set
            {
                ukupanIznos = value;
                OnPropertyChanged("UkupanIznos");
            }
        }

        //private Namestaj namestaj;

        //[XmlIgnore]
        //public Namestaj Namestaj
        //{
        //    get
        //    {
        //        if (namestaj == null)
        //        {
        //            namestaj = Namestaj.GetById(NamestajId);
        //        }
        //        return namestaj;
        //    }
        //    set
        //    {
        //        namestaj = value;
        //        NamestajId = namestaj.Id;
        //        OnPropertyChanged("Namestaj");
        //    }
        //}

        //private DodatnaUsluga dodatnaUsluga;

        //[XmlIgnore]
        //public DodatnaUsluga DodatnaUsluga
        //{
        //    get
        //    {
        //        if (dodatnaUsluga == null)
        //        {
        //            dodatnaUsluga = DodatnaUsluga.GetById(DodatnaUslugaId);
        //        }
        //        return dodatnaUsluga;
        //    }
        //    set
        //    {
        //        dodatnaUsluga = value;
        //        DodatnaUslugaId = dodatnaUsluga.Id;
        //        OnPropertyChanged("DodatnaUsluga");
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return $"{DatumProdaje}, {BrojRacuna}, {Kupac}, {DodatnaUsluga.GetById(DodatnaUslugaId).Naziv} , {PDV}, {UkupanIznos}";
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
                //StavkaProdaje = stavkaProdaje,
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
                    p.NamestajaId = int.Parse(row["StavkeNamestajaId"].ToString());
                    p.DodatnaUslugaId = int.Parse(row["StavkeUslugaId"].ToString());

                   prodaja.Add(p);
                }

            }


            return prodaja;
        }
        #endregion

        #region CRUD
        public static Namestaj Create(Namestaj n)
        {
            Random random = new Random();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "INSERT INTO Namestaj (Naziv, Sifra, Cena, Kolicina, TipNamestajaId, Obrisan) VALUES (@Naziv, @Sifra, @Cena, @Kolicina, @TipNamestajaId, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                n.Sifra = n.Naziv.Substring(0, 2).ToUpper() + random.Next(1, 50);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                //cmd.Parameters.AddWithValue("AkcijaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.Namestaji.Add(n);

            return n;
        }
        #endregion

        #region CRUD
        public static void Update(Namestaj n)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "UPDATE Namestaj SET Naziv=@Naziv, Sifra=@Sifra, Cena=@Cena, Kolicina=@Kolicina, TipNamestajaId=@TipNamestajaId, AkcijaId=@AkcijaId, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("AkcijaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();
            }

            foreach (var namestaj in Projekat.Instance.Namestaji)
            {
                if (n.Id == namestaj.Id)
                {
                    namestaj.Naziv = n.Naziv;
                    namestaj.Sifra = n.Sifra;
                    namestaj.JedinicnaCena = n.JedinicnaCena;
                    namestaj.KolicinaUMagacinu = n.KolicinaUMagacinu;
                    namestaj.AkcijskaProdaja = n.AkcijskaProdaja;
                    namestaj.AkcijaId = n.AkcijaId;
                    namestaj.TipNamestaja = n.TipNamestaja;
                    namestaj.TipNamestajaId = n.TipNamestajaId;
                    namestaj.Obrisan = n.Obrisan;
                }
            }
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}
