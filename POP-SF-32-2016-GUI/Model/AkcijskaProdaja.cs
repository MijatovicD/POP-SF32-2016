using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class AkcijskaProdaja : INotifyPropertyChanged
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

        private DateTime datumPocetka;

        public DateTime DatumPocetka
        {
            get
            {
                return datumPocetka;
            }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

        private decimal popust;

        public decimal Popust
        {
            get
            {
                return popust;
            }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }

        private DateTime datumZavrsetka;

        public DateTime DatumZavrsetka
        {
            get
            {
                return datumZavrsetka;
            }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }

        private List<Namestaj> namestajNaPopustu;

        public List<Namestaj> NamestajNaPopustu
        {
            get
            {
                return namestajNaPopustu;
            }
            set
            {
                namestajNaPopustu = value;
                OnPropertyChanged("NamestajNaPopustu");
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

        //public int Id { get; set; }
        //public DateTime DatumPocetka { get; set; }
        //public decimal Popust { get; set; }
        //public DateTime DatumZavrsetka { get; set; }
        //public List<Namestaj> NamestajNaPopustu { get; set; }
        //public bool Obrisan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{DatumPocetka}, {Popust}, {DatumZavrsetka}";
        }

        public static AkcijskaProdaja GetById(int id)
        {
            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
