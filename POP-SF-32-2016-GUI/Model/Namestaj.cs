﻿using POP_SF_32_2016_GUI.Model;
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

namespace POP_SF32_2016.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable, IDataErrorInfo
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

        private string sifra;

        public string Sifra
        {
            get
            {
                return sifra;
            }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        private double jedinicnaCena;

        public double JedinicnaCena
        {
            get
            {
                return jedinicnaCena;
            }
            set
            {
                jedinicnaCena = value;
                OnPropertyChanged("JedinicnaCena");
            }
        }

        private int kolicinaUMagacinu;

        public int KolicinaUMagacinu
        {
            get
            {
                return kolicinaUMagacinu;
            }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
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

        private int tipNamestajaId;

        public int TipNamestajaId
        {
            get
            {
                return tipNamestajaId;
            }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
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

        private TipNamestaja tipNamestaja;
        private AkcijskaProdaja akcijskaProdaja;

        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                try
                {
                    tipNamestaja = value;
                    TipNamestajaId = tipNamestaja.Id;
                    OnPropertyChanged("TipNamestaja");
                }
                catch (Exception)
                {

                    MessageBox.Show("Greska");
                }
            }
        }


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
                try
                {
                    akcijskaProdaja = value;
                    AkcijaId = akcijskaProdaja.Id;
                    OnPropertyChanged("AkcijskaProdaja");
                }
                catch (Exception)
                {
                    MessageBox.Show("Greska");
                }
            }
        }


        public string Error
        {
            get
            {
                return "Neispravni podaci o namestaju";
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
                    case "JedinicnaCena":
                        if (JedinicnaCena <= 0)
                        {
                            return "Mora biti veca od nule";
                        }
                        break;
                    case "KolicinaUMagacinu":
                        if (KolicinaUMagacinu <= 0)
                        {
                            return "Mora biti veca od nule";
                        }
                        break;
                }
                return "";
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
        //public StavkaProdaje StavkaProdaje
        //{
        //    get
        //    {
        //        if (stavkaProdaje == null)
        //        {
        //            stavkaProdaje = StavkaProdaje.GetById(StavkaProdajeId);
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

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Naziv}, {Sifra}, {JedinicnaCena}, {KolicinaUMagacinu}, {TipNamestaja.GetById(TipNamestajaId)?.Naziv}, {AkcijskaProdaja.GetById(AkcijaId)?.Naziv}";
        }



        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaji)
            {
                if (namestaj.Id == id)
                {
                    return namestaj;
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
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                Sifra = sifra,
                JedinicnaCena = jedinicnaCena,
                KolicinaUMagacinu = kolicinaUMagacinu,
                Obrisan = obrisan,
                AkcijaId = akcijaId,
                TipNamestajaId = tipNamestajaId
            };
        }

        #region CRUD
        public static ObservableCollection<Namestaj> GetAll()
        {
            var namestaj = new ObservableCollection<Namestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Sifra = row["Sifra"].ToString();
                    n.JedinicnaCena = double.Parse(row["Cena"].ToString());
                    n.KolicinaUMagacinu = int.Parse(row["Kolicina"].ToString());
                    n.AkcijaId = int.Parse(row["AkcijaId"].ToString());
                    n.TipNamestajaId = int.Parse(row["TipNamestajaId"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaj.Add(n);
                }

            }


            return namestaj;
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

                try
                {
                    cmd.CommandText = "INSERT INTO Namestaj (Naziv, Sifra, Cena, Kolicina, AkcijaId, TipNamestajaId, Obrisan) VALUES (@Naziv, @Sifra, @Cena, @Kolicina, @AkcijaId, @TipNamestajaId, @Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                    n.Sifra = n.Naziv.Substring(0, 2).ToUpper() + random.Next(1, 50) + n.TipNamestaja.Naziv.Substring(0,2).ToUpper();
                    cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                    cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                    cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                    cmd.Parameters.AddWithValue("AkcijaId", n.AkcijaId);
                    cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                    cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                    n.Id = int.Parse(cmd.ExecuteScalar().ToString());
                }


                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno dodavanje", "Greska");
                }

                Projekat.Instance.Namestaji.Add(n);

                return n;

            }
                
        }
        #endregion

        #region CRUD
        public static void Update(Namestaj n)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                
                try
                {

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
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspesno azuriranje", "Greska");
                }
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
