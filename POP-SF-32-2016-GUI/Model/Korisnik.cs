using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
    public class Korisnik : INotifyPropertyChanged, ICloneable
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


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Ime}, {Prezime}, {KorisnickoIme}, {TipKorisnika}";
        }


        public static Korisnik GetById(int id)
        {
            foreach (var korisnik in Projekat.Instance.Korisnik)
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
    }
}
