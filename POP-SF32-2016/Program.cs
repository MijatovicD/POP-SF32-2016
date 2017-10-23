using POP_SF32_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016
{
    class Program
    {
        static List<Namestaj> Namestaj {get; set;} = new List<Namestaj>();
        static List<TipNamestaja> TipNamestaja { get; set; } = new List<TipNamestaja>();
        static void Main(string[] args)
        {
            var s1 = new Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg Dositeja Obradovica 6",
                ZiroRacun = "840-00073666-83",
                Email = "kontakt@ftn.uns.ac.rs",
                MaticniBroj = 234324,
                PIB = 323443,
                Telefon = "021/342-343",
                InternetAdresa = "http://www.ftn.uns.ac.rs"
            };

            var tn1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Sofa",

            };

            var tn2 = new TipNamestaja()
            {
                Id = 2,
                Naziv = "Regal",
            };

            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "Super sofa",
                Sifra = "SF sifra za sofe",
                JedinicnaCena = 28,
                TipNamestaja = tn1,
                KolicinaUMagacinu = 2
            };

           

            Namestaj.Add(n1);

            Console.WriteLine($"===== Dobrodosli u salon{s1.Naziv}");

            IspisGlavnogMenija();


        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Glavni meni ===");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestajem");
                Console.WriteLine("0. Izlaz iz aplikacije");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 2);

            

            switch (izbor)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IspisiMeniNamestaja();
                    break;
                default:
                    break;
            }


        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("=== Meni namestaja ===");
                Console.WriteLine("1. Izlisaj namestaj");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci namestaj");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor <0 || izbor > 4);

          

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajNamestaj();
                    break;
                case 2:
                    DodavanjeNovogNamestaja();
                    break;
                case 3:
                    IzmenaNamestaja();
                    break;
                default:
                    break;
            }
        }

       

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("=== Izlistavanje namestaja ===");
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (!Namestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{Namestaj[i].Naziv},cena: {Namestaj[i].JedinicnaCena}, tip namestaja: {Namestaj[i].TipNamestaja}");
                }


            }
            IspisiMeniNamestaja();
        }

        private static void DodavanjeNovogNamestaja()
        {
            Console.WriteLine("=== Dodavanje novog namestaja ===");
            var noviNamestaj = new Namestaj();
            noviNamestaj.Id = Namestaj.Count + 1;
            //noviNamestaj.Id = noviNamestaj.GetHashCode();

            Console.WriteLine("Unesite naziv: ");
            noviNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            noviNamestaj.JedinicnaCena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite sifru: ");
            noviNamestaj.Sifra = Console.ReadLine();
           
            Console.WriteLine("Unesite kolicinu: ");
            noviNamestaj.KolicinaUMagacinu = int.Parse(Console.ReadLine());

            string nazivTipaNamestaja = "";
            TipNamestaja trazeniTipNamestaja = null;
            //da korisnik moze da unese tip namestaja koji postoji u listi
            
            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                nazivTipaNamestaja = Console.ReadLine();
                foreach (var tipNamestaja in TipNamestaja)
                {
                    if (tipNamestaja.Naziv == nazivTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);


            noviNamestaj.TipNamestaja = trazeniTipNamestaja;

            Namestaj.Add(noviNamestaj);

            IspisiMeniNamestaja();
       
        }

        private static void IzmenaNamestaja()
        {
            Namestaj trazeniNamestaj = null;
            string nazivTrazenogNamestaja = "";

            do
            {
                Console.WriteLine("Unesite naziv namestaja: ");
                nazivTrazenogNamestaja = Console.ReadLine();

               foreach(var namestaj in Namestaj)
                {
                    if(namestaj.Naziv == nazivTrazenogNamestaja)
                    {
                        trazeniNamestaj = namestaj;
                    }
                }

            } while (trazeniNamestaj == null);

            Console.WriteLine("Unesite novi naziv namestaja: ");
            trazeniNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite novu cenu namestaja: ");
            trazeniNamestaj.JedinicnaCena = double.Parse(Console.ReadLine());

            IspisiMeniNamestaja();
            
            

        }
    }
}
