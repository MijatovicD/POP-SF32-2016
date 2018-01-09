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

namespace POP_SF32_2016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable, IDataErrorInfo
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

        private string naziv;

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        private double cena;

        public double Cena
        {
            get
            {
                return cena;
            }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
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

        public string Error
        {
            get
            {
                return "Neispravni podaci o dodatnoj usluzi";
            }
        }

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "Naziv":
                        if (string.IsNullOrEmpty(Naziv))
                            return "Polje ne sme biti prazno";
                        break;
                    case "Cena":
                        if (Cena < 0)
                        {
                            return "Mora biti veca od nule";
                        }
                        break;
                }
                return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Naziv}, {Cena}";
        }


        public static DodatnaUsluga GetById(int id)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluge)
            {
                if (usluga.Id == id)
                {
                    return usluga;
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
            return new DodatnaUsluga()
            {
                Id = id,
                Naziv = naziv,
                Cena = cena
            };
        }

        #region CRUD
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var dodatnaUsluga = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga");

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["Id"].ToString());
                    du.Naziv = row["Naziv"].ToString();
                    du.Cena = double.Parse(row["Cena"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    dodatnaUsluga.Add(du);
                }

            }


            return dodatnaUsluga;
        }
        #endregion

        #region CRUD
        public static DodatnaUsluga Create(DodatnaUsluga du)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) VALUES (@Naziv, @Cena, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                du.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Projekat.Instance.DodatnaUsluge.Add(du);

            return du;
        }
        #endregion

        #region CRUD
        public static void Update(DodatnaUsluga du)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "UPDATE DodatnaUsluga SET Naziv=@Naziv, Cena=@Cena, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Id", du.Id);
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                cmd.ExecuteNonQuery();
            }

            foreach (var dodatnaUsluga in Projekat.Instance.DodatnaUsluge)
            {
                if (du.Id == dodatnaUsluga.Id)
                {
                    dodatnaUsluga.Naziv = du.Naziv;
                    dodatnaUsluga.Cena = du.Cena;
                    dodatnaUsluga.Obrisan = du.Obrisan;
                }
            }
        }

        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Update(du);
        }
        #endregion
    }
}