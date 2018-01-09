using POP_SF32_2016.Model;
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
using System.Windows;
using System.Xml.Serialization;

namespace POP_SF_32_2016_GUI.Model
{
    public class StavkaNamestaja : INotifyPropertyChanged, ICloneable

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

        private int namestajId;

        public int NamestajId
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

        private Namestaj namestaj;

        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if (namestaj == null)
                {
                    namestaj = Namestaj.GetById(NamestajId);
                }
                return namestaj;
            }
            set
            {
                namestaj = value;
                NamestajId = namestaj.Id;
                OnPropertyChanged("Namestaj");
            }
        }

        private int idProdaje;

        public int IdProdaje
        {
            get
            {
                return idProdaje;
            }
            set
            {
                idProdaje = value;
                OnPropertyChanged("IdProdaje");
            }
        }

        private ProdajaNamestaja prodaja;

        [XmlIgnore]
        public ProdajaNamestaja prodajaNamestaja
        {
            get
            {
                if (prodaja == null)
                {
                    prodaja = ProdajaNamestaja.GetById(IdProdaje);
                }
                return prodaja;
            }
            set
            {
                prodaja = value;
                IdProdaje = prodaja.Id;
                OnPropertyChanged("IdProdaje");
            }
        }



        private int kolicinaNamestaja;

        public int KolicinaNamestaja
        {
            get
            {
                return kolicinaNamestaja;
            }
            set
            {
                kolicinaNamestaja = value;
                OnPropertyChanged("KolicinaNamestaja");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public static StavkaNamestaja GetById(int id)
        {
            foreach (var stavka in Projekat.Instance.StavkeNamestaja)
            {
                if (stavka.Id == id)
                {
                    return stavka;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Namestaj.GetById(NamestajId).Naziv}, {Namestaj.GetById(NamestajId).JedinicnaCena}, {KolicinaNamestaja}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return new StavkaNamestaja()
            {
                NamestajId = namestajId,
                KolicinaNamestaja = kolicinaNamestaja
            };
        }

        #region CRUD
        public static ObservableCollection<StavkaNamestaja> GetAll()
        {
            var stavka = new ObservableCollection<StavkaNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM StavkeNamestaja WHERE NamestajId NOT IN (SELECT Id FROM Namestaj);";
                da.SelectCommand = cmd;
                da.Fill(ds, "StavkeNamestaja");

                foreach (DataRow row in ds.Tables["StavkeNamestaja"].Rows)
                {
                    var a = new StavkaNamestaja();
                    a.Id = int.Parse(row["Id"].ToString());
                    a.IdProdaje = int.Parse(row["IdProdaje"].ToString());
                    a.NamestajId = int.Parse(row["NamestajId"].ToString());
                    a.KolicinaNamestaja = int.Parse(row["Kolicina"].ToString());

                    stavka.Add(a);
                }

            }


            return stavka;
        }
        #endregion

        #region CRUD
        public static StavkaNamestaja Create(StavkaNamestaja s)
        {
            var lista = Projekat.Instance.ProdajeNamestaja;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO StavkeNamestaja (NamestajId, Kolicina) VALUES (@NamestajId, @Kolicina);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("NamestajId", s.NamestajId);
                    cmd.Parameters.AddWithValue("Kolicina", s.KolicinaNamestaja);

                    s.Id = int.Parse(cmd.ExecuteScalar().ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno dodavanje", "Greska");
                }

            }

            Projekat.Instance.StavkeNamestaja.Add(s);

            return s;
        }
        #endregion

    }
}
