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

namespace POP_SF32_2016.Model
{

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
    public class Korisnik : INotifyPropertyChanged, ICloneable, IDataErrorInfo
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

        private string ime;

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }


        private string prezime;

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        private string korisnicnkoIme;

        public string KorisnickoIme
        {
            get
            {
                return korisnicnkoIme;
            }
            set
            {
                korisnicnkoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

        private string lozinka;

        public string Lozinka
        {
            get
            {
                return lozinka;
            }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }

        private TipKorisnika tipKorisnika;

        public TipKorisnika TipKorisnika
        {
            get
            {
                return tipKorisnika;
            }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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
                return "Neispravni podaci o korisniku";
            }
        }

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "Ime":
                        if (string.IsNullOrEmpty(Ime))
                            return "Polje ne sme biti prazno";
                        break;
                    case "Prezime":
                        if (string.IsNullOrEmpty(Prezime))
                        {
                            return "Polje ne sme biti prazno";
                        }
                        break;
                }
                return "";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Ime}, {Prezime}, {KorisnickoIme}, {TipKorisnika}";
        }


        public static Korisnik GetById(int id)
        {
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (korisnik.Id == id)
                {
                    return korisnik;
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
            return new Korisnik()
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korisnicnkoIme,
                Lozinka = lozinka,
                TipKorisnika = tipKorisnika
            };
        }

        #region CRUD
        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnik = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var ko = new Korisnik();
                    ko.Id = int.Parse(row["Id"].ToString());
                    ko.Ime = row["Ime"].ToString();
                    ko.Prezime = row["Prezime"].ToString();
                    ko.KorisnickoIme = row["KorisnickoIme"].ToString();
                    ko.Lozinka = row["Lozinka"].ToString();
                    ko.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), (row["TipKorisnika"].ToString()));
                    ko.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korisnik.Add(ko);
                }

            }


            return korisnik;
        }
        #endregion

        #region CRUD
        public static Korisnik Create(Korisnik ko)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) VALUES (@Ime, @Prezime, @KorisnickoIme, @Lozinka, @TipKorisnika, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Ime", ko.Ime);
                    cmd.Parameters.AddWithValue("Prezime", ko.Prezime);
                    cmd.Parameters.AddWithValue("KorisnickoIme", ko.KorisnickoIme);
                    cmd.Parameters.AddWithValue("Lozinka", ko.Lozinka);
                    cmd.Parameters.AddWithValue("TipKorisnika", ko.TipKorisnika);
                    cmd.Parameters.AddWithValue("Obrisan", ko.Obrisan);

                    ko.Id = int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno dodavanje", "Greska");
                }

                Projekat.Instance.Korisnici.Add(ko);

                return ko;
            }

        }
        #endregion

        #region CRUD
        public static void Update(Korisnik ko)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "UPDATE Korisnik SET Ime=@Ime, Prezime=@Prezime, KorisnickoIme=@KorisnickoIme, Lozinka=@Lozinka, TipKorisnika=@TipKorisnika, Obrisan=@Obrisan WHERE Id=@Id;";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Id", ko.Id);
                    cmd.Parameters.AddWithValue("Ime", ko.Ime);
                    cmd.Parameters.AddWithValue("Prezime", ko.Prezime);
                    cmd.Parameters.AddWithValue("KorisnickoIme", ko.KorisnickoIme);
                    cmd.Parameters.AddWithValue("Lozinka", ko.Lozinka);
                    cmd.Parameters.AddWithValue("TipKorisnika", ko.TipKorisnika);
                    cmd.Parameters.AddWithValue("Obrisan", ko.Obrisan);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno azuriranje", "Greska");
                }

            }

            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (ko.Id == korisnik.Id)
                {
                    korisnik.Ime = ko.Ime;
                    korisnik.Prezime = ko.Prezime;
                    korisnik.KorisnickoIme = ko.KorisnickoIme;
                    korisnik.Lozinka = ko.Lozinka;
                    korisnik.TipKorisnika = ko.TipKorisnika;
                    korisnik.Obrisan = ko.Obrisan;
                }
            }
        }

        public static void Delete(Korisnik ko)
        {
            try
            {
                ko.Obrisan = true;
                Update(ko);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspesno brisanje", "Greska");
            }
        }
        #endregion
    }
}
