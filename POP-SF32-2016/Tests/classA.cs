using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstorImena
{
    class A
    {
        private string naziv;
        private string ime;

        public string GetNaziv()
        {
            return this.naziv;
        }

        public void SetNaziv(string naziv)
        {
            this.naziv = naziv;
        }

        public string Ime { get; set; }
    }
}
