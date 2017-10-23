using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class AkcijskaProdaja
    {
        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public decimal Popust { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public List<Namestaj> NamestajNaPopustu { get; set; }
        public bool Obrisan { get; set; }
    }
}
