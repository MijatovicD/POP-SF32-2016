using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        private List<Namestaj> namestajZaProdaju;

        public List<Namestaj> NamestajZaProdaju
        {
            get
            {
                return namestajZaProdaju;
            }
            set
            {
                namestajZaProdaju = value;
                OnPropertyChanged("NamestajZaProdaju");
            }
        }

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

        private List<DodatnaUsluga> dodatnaUsluga;

        public List<DodatnaUsluga> DodatnaUsluga
        {
            get
            {
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                OnPropertyChanged("DodatnaUsluga");
            }
        }

        private double pdv;

        public  double PDV
        {
            get
            {
                return pdv;
            }
            set
            {
                pdv = value;
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



        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return $"{Namestaj.GetById(System.Convert.ToInt16(namestajZaProdaju)).Id}, {DatumProdaje}, {BrojRacuna}, {Kupac}, {DodatnaUsluga}, {PDV}, {UkupanIznos}";
        }

        public static ProdajaNamestaja GetById(int id)
        {
            foreach (var prodaja in Projekat.Instance.ProdajaNamestaja)
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
                NamestajZaProdaju = namestajZaProdaju,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                DodatnaUsluga = dodatnaUsluga,
                PDV = pdv,
                UkupanIznos = ukupanIznos
            };
        }
    }
}
