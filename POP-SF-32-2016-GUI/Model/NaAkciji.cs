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
using System.Xml.Serialization;

namespace POP_SF_32_2016_GUI.Model
{
    public class NaAkciji : INotifyPropertyChanged
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

        private int akcijaId;

        public int AkcijaId
        {
            get
            {
                return akcijaId;
            }
            set
            {
                akcijaId = value;
                OnPropertyChanged("AkcijaId");
            }
        }

        private AkcijskaProdaja akcijskaProdaja;

        public AkcijskaProdaja AkcijskaProdaja
        {
            get
            {
                if (akcijskaProdaja == null)
                {
                    akcijskaProdaja = AkcijskaProdaja.GetById(AkcijaId);
                }
                return akcijskaProdaja;
            }
            set
            {
                akcijskaProdaja = value;
                AkcijaId = akcijskaProdaja.Id;
                OnPropertyChanged("AkcijskaProdaja");
            }
        }

        private bool obrisan;

        public bool Obrisan
        {
            get
            {
                return obrisan;
            }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Namestaj.GetById(NamestajId).Naziv}, {AkcijskaProdaja.GetById(AkcijaId).Naziv}";
        }


        #region CRUD
        public static ObservableCollection<NaAkciji> GetAll()
        {
            var naAkciji = new ObservableCollection<NaAkciji>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM NaAkciji WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "NaAkciji");

                foreach (DataRow row in ds.Tables["NaAkciji"].Rows)
                {
                    var a = new NaAkciji();
                    a.Id = int.Parse(row["Id"].ToString());
                    a.NamestajId = int.Parse(row["NamestajId"].ToString());
                    a.AkcijaId = int.Parse(row["AkcijaId"].ToString());
                    a.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    naAkciji.Add(a);
                }

            }


            return naAkciji;
        }
        #endregion

        #region CRUD
        public static NaAkciji Create(NaAkciji a)
        {
          
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "INSERT INTO NaAkciji (NamestajId, AkcijaId, Obrisan) VALUES (@NamestajId, @AkcijaId, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("NamestajId", a.NamestajId);
                cmd.Parameters.AddWithValue("AkcijaId", a.AkcijaId);
                cmd.Parameters.AddWithValue("Obrisan", a.Obrisan);

                a.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.Akcija.Add(a);

            return a;
        }
        #endregion

    }
}
