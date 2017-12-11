using POP_SF_32_2016_GUI.Model;
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

        public ObservableCollection<Namestaj> Namestaji { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }
        public ObservableCollection<AkcijskaProdaja> AkcijskaProdaja { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<StavkaProdaje> StavkaProdaje { get; set; }

        private Projekat()
        {
            TipoviNamestaja = TipNamestaja.GetAll();
            Namestaji = Namestaj.GetAll();
            AkcijskaProdaja = GenericSerializer.Deserialize<AkcijskaProdaja>("akcijskaProdaja.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
            Salon = GenericSerializer.Deserialize<Salon>("salon.xml");
            StavkaProdaje = GenericSerializer.Deserialize<StavkaProdaje>("stavkaProdaje.xml");
        }
    }
}