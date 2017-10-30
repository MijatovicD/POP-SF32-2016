using POP_SF32_2016.Model;
using POP_SF32_2016.Until;
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
        static List<Korisnik> Korisnik { get; set; } = new List<Korisnik>();
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
                TipNamestajaId = 1,
                KolicinaUMagacinu = 2
            };

            var n2 = new Namestaj()
            {
                Id = 2,
                Naziv = "Extra sofa",
                Sifra = "SN sifra za sofe",
                JedinicnaCena = 34,
                TipNamestajaId = 2,
                KolicinaUMagacinu = 8
            };

            var k1 = new Korisnik()
            {
                Id = 3,
                Ime = "Pera",
                Prezime = "Peric"
            };


            Namestaj.Add(n1);
            TipNamestaja.Add(tn1);
            Korisnik.Add(k1);
           

            var ln1 = new List<Namestaj>();
            ln1.Add(n1);

            var ln2 = new List<TipNamestaja>();
            ln2.Add(tn1);

            var lk1 = new List<Korisnik>();
            lk1.Add(k1);



            Console.WriteLine("Sirijalicija...");


            Console.WriteLine("Unesite naziv namestaja: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite id tipa namestaja: ");
            int idTipNamestaja = int.Parse(Console.ReadLine());



            GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", ln2);
            GenericSerializer.Serialize<Korisnik>("korisnik.xml", lk1);

            List<Namestaj> ucitanaLista = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");

            Console.WriteLine("Finised sirijalicajija");
            Console.ReadLine();

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
                case 2:
                    IspisiMeniTipaNamestaja();
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
                case 4:
                    IzbrisiNamestaj();
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
                    Console.WriteLine($"{i + 1}.{Namestaj[i].Naziv},cena: {Namestaj[i].JedinicnaCena}, tip namestaja: {Namestaj[i].TipNamestaja.Naziv}");
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
            int iDTrazenogNamestaja = 0;

            do
            {
                Console.WriteLine("Unesite id namestaja: ");
                iDTrazenogNamestaja = int.Parse(Console.ReadLine());

               foreach(var namestaj in Namestaj)
                {
                    if(namestaj.Id == iDTrazenogNamestaja)
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

        private static void IzbrisiNamestaj()
        {
            Namestaj trazeniNamestaj = null;
            int iDTrazenogNamestaja = 0;

            Console.WriteLine("Unesite id namestaja: ");
            iDTrazenogNamestaja = int.Parse(Console.ReadLine());

                foreach (var namestaj in Namestaj)
                {
                    if (namestaj.Id == iDTrazenogNamestaja)
                    {
                        namestaj.Obrisan = true;
                    }
                }

            IspisiMeniNamestaja();
        }

        private static void IspisiMeniTipaNamestaja()
        {

            int izbor = 0;

            do
            {
                Console.WriteLine("=== Meni tipa namestaja ===");
                Console.WriteLine("1. Izlisaj tipove namestaja");
                Console.WriteLine("2. Dodaj novi tip namestaj");
                Console.WriteLine("3. Izmeni postojeci tip namestaj");
                Console.WriteLine("4. Obrisi postojeci tip namestaja");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);


            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajTipNamestaj();
                    break;
                case 2:
                    DodavanjeNovogTipaNamestaja();
                    break;
                case 3:
                    IzmenaTipaNamestaja();
                    break;
                case 4:
                    IzbrisiTipNamestaj();
                    break;
                default:
                    break;
            }

        }

        private static void IzlistajTipNamestaj()
        {
            Console.WriteLine("=== Izlistavanje tipa namestaja ===");

            for (int i = 0; i < TipNamestaja.Count; i++)
            {
                if (!TipNamestaja[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{TipNamestaja[i].Naziv}");
                }
            }

            IspisiMeniTipaNamestaja();
        }

        private static void DodavanjeNovogTipaNamestaja()
        {
            Console.WriteLine("=== Dodavanje tipa namestaja ===");

            var noviTipNamestaj = new TipNamestaja();
            noviTipNamestaj.Id = TipNamestaja.Count + 1;

            Console.WriteLine("Unesite naziv tipa namestaja: ");
            noviTipNamestaj.Naziv = Console.ReadLine();

            TipNamestaja.Add(noviTipNamestaj);
            IspisiMeniTipaNamestaja();

        }

        private static void IzmenaTipaNamestaja()
        {

            TipNamestaja trazeniTipNamestaj = null;
            int iDTrazenogTipaNamestaja = 0;

            do
            {
                Console.WriteLine("Unesite id tipa namestaja: ");
                iDTrazenogTipaNamestaja = int.Parse(Console.ReadLine());

                foreach (var tipNamestaja in TipNamestaja)
                {
                    if (tipNamestaja.Id == iDTrazenogTipaNamestaja)
                    {
                        trazeniTipNamestaj = tipNamestaja;
                    }
                }

            } while (trazeniTipNamestaj == null);

            Console.WriteLine("Unesite novi naziv namestaja: ");
            trazeniTipNamestaj.Naziv = Console.ReadLine();
            
            IspisiMeniTipaNamestaja();

        }


        private static void IzbrisiTipNamestaj()
        {

            TipNamestaja trazeniTipNamestaj = null;
            int iDTrazenogTipaNamestaja = 0;

            Console.WriteLine("Unesite id tipa namestaja: ");
            iDTrazenogTipaNamestaja = int.Parse(Console.ReadLine());

            foreach (var tipNamestaja in TipNamestaja)
            {
                if (tipNamestaja.Id == iDTrazenogTipaNamestaja)
                {
                    tipNamestaja.Obrisan = true;
                }
            }

            IspisiMeniTipaNamestaja();

        }
   
    }

}