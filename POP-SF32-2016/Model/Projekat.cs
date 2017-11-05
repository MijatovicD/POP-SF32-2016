using POP_SF32_2016.Until;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        private List<Namestaj> namestaj;

        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return namestaj;
            }
            set
            {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
            }
        }


        private List<TipNamestaja> tipNamestaja;

        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.tipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipoviNamestaja.xml");
                return tipNamestaja;
            }
            set
            {
                this.tipNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", tipNamestaja);
            }
        }
        

        private List<Korisnik> korisnik;

        public List<Korisnik> Korisnik
        {
            get
            {
                this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return korisnik;
            }
            set
            {
                korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnik);
            }
        }
       

        private List<DodatnaUsluga> dodatnaUsluga;

        public List<DodatnaUsluga> DodatnaUsluga
        {
            get
            {
                this.dodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", dodatnaUsluga);
            }
        }

        
        private List<Salon> salon;

        public List<Salon> Salon
        {
            get
            {
                this.salon = GenericSerializer.Deserialize<Salon>("salon.xml");
                return salon;
            }
            set
            {
                salon = value;
                GenericSerializer.Serialize<Salon>("salon.xml", salon);
            }
        }


        private List<AkcijskaProdaja> akcijskaProdaja;

        public List<AkcijskaProdaja> AkcijskaProdaja
        {
            get
            {
                this.akcijskaProdaja = GenericSerializer.Deserialize<AkcijskaProdaja>("akcijskaProdaja.xml");
                return akcijskaProdaja;
            }
            set
            {
                akcijskaProdaja = value;
                GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", akcijskaProdaja);
            }
        }


        private List<ProdajaNamestaja> prodajaNamestaja;

        public List<ProdajaNamestaja> ProdajaNamestaja
        {
            get
            {
                this.prodajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
                return prodajaNamestaja;
            }
            set
            {
                prodajaNamestaja = value;
                GenericSerializer.Serialize<ProdajaNamestaja>("prodajaNamestaja.xml", prodajaNamestaja);
            }
        }

    }
}