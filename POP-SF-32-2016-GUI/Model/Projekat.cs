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
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluge { get; set; }
        public ObservableCollection<Salon> Saloni { get; set; }
        public ObservableCollection<AkcijskaProdaja> AkcijskeProdaje { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<StavkaProdaje> StavkaProdaje { get; set; }

        private Projekat()
        {
            TipoviNamestaja = TipNamestaja.GetAll();
            Namestaji = Namestaj.GetAll();
            AkcijskeProdaje = AkcijskaProdaja.GetAll();
            Korisnici = Korisnik.GetAll();
            ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
            DodatnaUsluge = DodatnaUsluga.GetAll();
            Saloni = Salon.GetAll();
            StavkaProdaje = GenericSerializer.Deserialize<StavkaProdaje>("stavkaProdaje.xml");
        }
    }
}