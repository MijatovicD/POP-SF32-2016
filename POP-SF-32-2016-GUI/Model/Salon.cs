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
    public class Salon : INotifyPropertyChanged, ICloneable
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

        private String naziv;

        public String Naziv
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

        private String adresa;

        public String Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        private String telefon;

        public String Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                OnPropertyChanged("Telfon");
            }
        }

        private String email;

        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private String internetAdresa;

        public String InternetAdresa
        {
            get
            {
                return internetAdresa;
            }
            set
            {
                internetAdresa = value;
                OnPropertyChanged("InternetAdresa");
            }
        }

        private int pib;

        public int PIB
        {
            get
            {
                return pib;
            }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

        private int maticniBroj;

        public int MaticniBroj
        {
            get
            {
                return maticniBroj;
            }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }

        private String ziroRacun;

        public String ZiroRacun
        {
            get
            {
                return ziroRacun;
            }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
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

        public override string ToString()
        {
            return $"{Naziv}, {Adresa}, {Telefon}, {Email}, {InternetAdresa}, {PIB}, {MaticniBroj}, {ZiroRacun}";
        }

        public static Salon GetById(int id)
        {
            foreach (var salon in Projekat.Instance.Saloni)
            {
                if (salon.Id == id)
                {
                    return salon;
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
            return new Salon()
            {
                Id = id,
                Naziv = naziv,
                Adresa = adresa,
                Telefon = telefon,
                Email = email,
                InternetAdresa = internetAdresa,
                PIB = pib,
                MaticniBroj = maticniBroj,
                ZiroRacun = ziroRacun
            };
        }

        #region CRUD
        public static ObservableCollection<Salon> GetAll()
        {
            var salon = new ObservableCollection<Salon>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Salon;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Salon");

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var sl = new Salon();
                    sl.Id = int.Parse(row["Id"].ToString());
                    sl.Naziv = row["Naziv"].ToString();
                    sl.Adresa = row["Adresa"].ToString();
                    sl.Telefon = row["Telefon"].ToString();
                    sl.Email = row["Email"].ToString();
                    sl.InternetAdresa = row["InternetAdresa"].ToString();
                    sl.PIB = int.Parse(row["Pib"].ToString());
                    sl.MaticniBroj = int.Parse(row["MaticniBroj"].ToString());
                    sl.ZiroRacun = row["ZiroRacun"].ToString();


                    salon.Add(sl);
                }

            }


            return salon;
        }
        #endregion
    }
}
