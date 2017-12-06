using POP_SF32_2016.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_32_2016_GUI.Model
{
    public class StavkaProdaje : INotifyPropertyChanged

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

        private Namestaj namestaj;

        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if (namestaj == null)
                {
                    namestaj = Namestaj.GetById(NamestajId);
                }
                return namestaj;
            }
            set
            {
                namestaj = value;
                NamestajId = namestaj.Id;
                OnPropertyChanged("Namestaj");
            }
        }



        private int kolicinaNamestaja;

        public int KolicinaNamestaja
        {
            get
            {
                return kolicinaNamestaja;
            }
            set
            {
                kolicinaNamestaja = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public static StavkaProdaje GetById(int id)
        {
            foreach (var stavka in Projekat.Instance.StavkaProdaje)
            {
                if (stavka.Id == id)
                {
                    return stavka;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Namestaj.GetById(NamestajId).Naziv}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
