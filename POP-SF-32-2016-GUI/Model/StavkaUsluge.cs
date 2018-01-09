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
    public class StavkaUsluge : INotifyPropertyChanged
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

        private int uslugaId;

        public int UslugaId
        {
            get
            {
                return uslugaId;
            }
            set
            {
                uslugaId = value;
                OnPropertyChanged("Usluga");
            }
        }

        private DodatnaUsluga dodatnaUsluga;

        [XmlIgnore]
        public DodatnaUsluga DodatnaUsluga
        {
            get
            {
                if (dodatnaUsluga == null)
                {
                    dodatnaUsluga = DodatnaUsluga.GetById(UslugaId);
                }
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                UslugaId = dodatnaUsluga.Id;
                OnPropertyChanged("DodatnaUsluga");
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


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public override string ToString()
        {
            return $"{DodatnaUsluga.GetById(UslugaId).Naziv}";
        }

        public static StavkaUsluge GetById(int id)
        {
            foreach (var stavka in Projekat.Instance.StavkeUsluge)
            {
                if (stavka.Id == id)
                {
                    return stavka;
                }
            }
            return null;
        }

        #region CRUD
        public static ObservableCollection<StavkaUsluge> GetAll()
        {
            var stavka = new ObservableCollection<StavkaUsluge>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM StavkeUsluge WHERE UslugaId NOT IN (SELECT Id FROM DodatnaUsluga);";
                da.SelectCommand = cmd;
                da.Fill(ds, "StavkeUsluge");

                foreach (DataRow row in ds.Tables["StavkeUsluge"].Rows)
                {
                    var u = new StavkaUsluge();
                    u.Id = int.Parse(row["Id"].ToString());
                    u.UslugaId = int.Parse(row["UslugaId"].ToString());
                    u.IdProdaje = int.Parse(row["IdProdaje"].ToString());

                    stavka.Add(u);
                }

            }


            return stavka;
        }
        #endregion

        #region CRUD
        public static StavkaUsluge Create(StavkaUsluge u)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO StavkeUsluge (UslugaId) VALUES (@UslugaId);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("UslugaId", u.UslugaId);

                    u.Id = int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno dodavanje", "Greska");
                }

            }

            Projekat.Instance.StavkeUsluge.Add(u);

            return u;
        }
        #endregion

    }
}
