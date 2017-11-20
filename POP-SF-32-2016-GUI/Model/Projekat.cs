using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<Namestaj> Namestaj { get; set; }

        //public List<Namestaj> Namestaj
        //{
        //    get
        //    {
        //        this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
        //        return namestaj;
        //    }
        //    set
        //    {
        //        this.namestaj = value;
        //        GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
        //    }
        //}


        public ObservableCollection<TipNamestaja> TipNamestaja { get; set; }

        //public ObservableCollection<TipNamestaja> TipNamestaja
        //{
        //    get
        //    {
        //        this.tipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
        //        return tipNamestaja;
        //    }
        //    set
        //    {
        //        this.tipNamestaja = value;
        //        GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", tipNamestaja);
        //    }
        //}

        public ObservableCollection<Korisnik> Korisnik { get; set; }
        //private List<Korisnik> korisnik;

        //public List<Korisnik> Korisnik
        //{
        //    get
        //    {
        //        this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
        //        return korisnik;
        //    }
        //    set
        //    {
        //        korisnik = value;
        //        GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnik);
        //    }
        //}

        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        //private List<DodatnaUsluga> dodatnaUsluga;

        //public List<DodatnaUsluga> DodatnaUsluga
        //{
        //    get
        //    {
        //        this.dodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
        //        return dodatnaUsluga;
        //    }
        //    set
        //    {
        //        dodatnaUsluga = value;
        //        GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", dodatnaUsluga);
        //    }
        //}

        public ObservableCollection<Salon> Salon { get; set; }
        //private List<Salon> salon;

        //public List<Salon> Salon
        //{
        //    get
        //    {
        //        this.salon = GenericSerializer.Deserialize<Salon>("salon.xml");
        //        return salon;
        //    }
        //    set
        //    {
        //        salon = value;
        //        GenericSerializer.Serialize<Salon>("salon.xml", salon);
        //    }
        //}

        public ObservableCollection<AkcijskaProdaja> AkcijskaProdaja { get; set; }
        //private List<AkcijskaProdaja> akcijskaProdaja;

        //public List<AkcijskaProdaja> AkcijskaProdaja
        //{
        //    get
        //    {
        //        this.akcijskaProdaja = GenericSerializer.Deserialize<AkcijskaProdaja>("akcijskaProdaja.xml");
        //        return akcijskaProdaja;
        //    }
        //    set
        //    {
        //        akcijskaProdaja = value;
        //        GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", akcijskaProdaja);
        //    }
        //}

        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        //private List<ProdajaNamestaja> prodajaNamestaja;

        //public List<ProdajaNamestaja> ProdajaNamestaja
        //{
        //    get
        //    {
        //        this.prodajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
        //        return prodajaNamestaja;
        //    }
        //    set
        //    {
        //        prodajaNamestaja = value;
        //        GenericSerializer.Serialize<ProdajaNamestaja>("prodajaNamestaja.xml", prodajaNamestaja);
        //    }
        //}

        private Projekat()
        {
            TipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            AkcijskaProdaja = GenericSerializer.Deserialize<AkcijskaProdaja>("akcijskaProdaja.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
            Salon = GenericSerializer.Deserialize<Salon>("salon.xml");
        }
    }
}