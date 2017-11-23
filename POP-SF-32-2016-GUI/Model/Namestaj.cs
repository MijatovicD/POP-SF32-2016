﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF32_2016.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private TipNamestaja tipNamestaja;
        private AkcijskaProdaja akcijskaProdaja;

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if(tipNamestaja == null)
                {
                   tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }


        [XmlIgnore]
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

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Naziv}, {Sifra}, {JedinicnaCena}, {KolicinaUMagacinu}, {AkcijskaProdaja.GetById(AkcijaId).DatumPocetka}, {TipNamestaja.GetById(TipNamestajaId).Naziv}";
        }



        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
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
    }
}
