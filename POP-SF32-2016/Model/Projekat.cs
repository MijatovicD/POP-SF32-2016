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
                return this.namestaj;
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
                this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
                return korisnik;
            }
            set
            {
                this.korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnici.xml", korisnik);
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
                this.dodatnaUsluga = value;
                GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", dodatnaUsluga);
            }
        }


    }
}
