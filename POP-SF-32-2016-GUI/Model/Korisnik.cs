using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public bool Obrisan { get; set; }

        public override string ToString()
        {
            return $"{Ime}, {Prezime}, {KorisnickoIme}, {TipKorisnika}";
        }


        public static Korisnik GetById(int id)
        {
            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (korisnik.Id == id)
                {
                    return korisnik;
                }
            }
            return null;
        }
    }
}
