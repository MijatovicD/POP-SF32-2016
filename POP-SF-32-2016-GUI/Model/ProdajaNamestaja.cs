using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class ProdajaNamestaja
    {
        public int Id { get; set; }
        public List<Namestaj> NamestajZaProdaju { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string BrojRacuna { get; set; }
        public string Kupac { get; set; }
        public List<DodatnaUsluga> DodatnaUsluga { get; set; }
        public const double PDV = 0.02;
        public double UkupanIznos { get; set; }

        public override string ToString()
        {
            return $"{NamestajZaProdaju}, {DatumProdaje}, {BrojRacuna}, {Kupac}, {DodatnaUsluga}, {PDV}, {UkupanIznos}";
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

    }
}
