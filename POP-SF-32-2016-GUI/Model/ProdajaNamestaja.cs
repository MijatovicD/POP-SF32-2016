using POP_SF_32_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        //private int namestajId;

        //public int NamestajId
        //{
        //    get
        //    {
        //        return namestajId;
        //    }
        //    set
        //    {
        //        namestajId = value;
        //        OnPropertyChanged("NamestajId");
        //    }
        //}

        private ObservableCollection<StavkaProdaje> stavkaProdaje;

        public ObservableCollection<StavkaProdaje> StavkaProdaje
        {
            get
            {
                return stavkaProdaje;
            }
            set
            {
                stavkaProdaje = value;
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

        private int dodatnaUslugaId;
        public int DodatnaUslugaId
        {
            get
            {
                return dodatnaUslugaId;
            }
            set
            {
                dodatnaUslugaId = value;
                OnPropertyChanged("DodatnaUslugaId");
            }
        }
        private const double pdv = 0.02;

        public  double PDV
        {
            get
            {
                return pdv;
            }
            set
            {
                //pdv = 0.02;
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

        //private Namestaj namestaj;

        //[XmlIgnore]
        //public Namestaj Namestaj
        //{
        //    get
        //    {
        //        if (namestaj == null)
        //        {
        //            namestaj = Namestaj.GetById(NamestajId);
        //        }
        //        return namestaj;
        //    }
        //    set
        //    {
        //        namestaj = value;
        //        NamestajId = namestaj.Id;
        //        OnPropertyChanged("Namestaj");
        //    }
        //}

        //private DodatnaUsluga dodatnaUsluga;

        //[XmlIgnore]
        //public DodatnaUsluga DodatnaUsluga
        //{
        //    get
        //    {
        //        if (dodatnaUsluga == null)
        //        {
        //            dodatnaUsluga = DodatnaUsluga.GetById(DodatnaUslugaId);
        //        }
        //        return dodatnaUsluga;
        //    }
        //    set
        //    {
        //        dodatnaUsluga = value;
        //        DodatnaUslugaId = dodatnaUsluga.Id;
        //        OnPropertyChanged("DodatnaUsluga");
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return $"{DatumProdaje}, {BrojRacuna}, {Kupac}, {DodatnaUsluga.GetById(DodatnaUslugaId).Naziv} , {PDV}, {UkupanIznos}";
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
                StavkaProdaje = stavkaProdaje,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                PDV = pdv,
                UkupanIznos = ukupanIznos
            };
        }
    }
}
