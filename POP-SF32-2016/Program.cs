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
        /*
        static List<Namestaj> Namestaj { get; set; } = Projekat.Instance.Namestaj;
        static List<TipNamestaja> TipNamestaja { get; set; } = Projekat.Instance.TipNamestaja;
        static List<Korisnik> Korisnik { get; set; } = Projekat.Instance.Korisnik;
        static List<DodatnaUsluga> DodatnaUsluga { get; set; } = Projekat.Instance.DodatnaUsluga;
        static List<Salon> Salon { get; set; } = Projekat.Instance.Salon;
        */
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
            /*
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
                Id = 1,
                Ime = "Pera",
                Prezime = "Peric",
                KorisnickoIme = "pera12",
                Lozinka = "12pera",
                TipKorisnikaId = 0 
            };

            var d1 = new DodatnaUsluga()
            {
                Id = 1,
                Naziv = "Montiranje",
                Cena = 1000
            };

            
            Salon.Add(s1);
            Namestaj.Add(n1);
            TipNamestaja.Add(tn1);
            Korisnik.Add(k1);
            DodatnaUsluga.Add(d1);
            */





            Console.WriteLine($"=== Dobrodosli u salon {s1.Naziv} ===");
            LogIn();
            /*
            Console.WriteLine("Serializition....");
            GenericSerializer.Serialize<Namestaj>("namestaj.xml", ln1);
            GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", ln2);
            GenericSerializer.Serialize<Korisnik>("korisnik.xml", lk1);
            GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", ld1);

            var namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");

            Console.WriteLine("Unesite naziv namestaja: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite id: ");
            int idTipaNamestaja = int.Parse(Console.ReadLine());

            namestaj.Add(new Namestaj() { Id = 13, Naziv = naziv, TipNamestajaId = idTipaNamestaja });

            //TipNamestaja trazeniTip = TipNamestaja.GetById(idTipaNamestaja);

            Projekat.Instance.Namestaj = namestaj;

            Console.WriteLine("Finised sirijalicajija");
            Console.ReadLine();
            



            var lista = Projekat.Instance.Namestaj;
            //lista.RemoveAt(lista.Count -1)
            lista.Add(new Namestaj() { Id = 28, Naziv = "Remix knjaz" });
            Projekat.Instance.Namestaj = lista;

            foreach (var stavka in lista)
            {
                Console.WriteLine($"(stavka.Naziv)");
            }
            Console.ReadLine();

            var lista1 = Projekat.Instance.TipNamestaja;
            lista1.Add(new TipNamestaja() { Id = 12, Naziv = "Fotelja na razvlacenje" });
            Projekat.Instance.TipNamestaja = lista1;

            foreach (var stavka in lista1)
            {
                Console.WriteLine($"(stavka.Naziv)");
            }
            Console.ReadLine();
            
            var lista2 = Projekat.Instance.Korisnik;
            lista2.Add(new Korisnik() { Id = 12, Ime = "Pera" });
            Projekat.Instance.Korisnik = lista2;

            foreach (var stavka in lista2)
            {
                Console.WriteLine($"(stavka.Ime)");
            }
            Console.ReadLine();
            */
        }

        private static void LogIn()
        {
            var korisnik = Projekat.Instance.Korisnik;
            Console.WriteLine("Unesite korisnicko ime: ");
            var korisnickoIme = Console.ReadLine();
            Console.WriteLine("Unesite lozinku: ");
            var lozinka = Console.ReadLine();
            TipKorisnika tipKorisnika;

            foreach (var k in korisnik)
            {
                if (k.KorisnickoIme.Equals(korisnickoIme) && k.Lozinka.Equals(lozinka))
                {
                    tipKorisnika = k.TipKorisnika;

                    switch (tipKorisnika)
                    {
                        case TipKorisnika.Administrator:
                            Console.WriteLine("Administrator");
                            break;
                        case TipKorisnika.Prodavac:
                            Console.WriteLine("Prodavac");
                            break;
                        default:
                            break;
                    }
                    IspisGlavnogMenija();
                }
            }
        }
        private static void IspisGlavnogMenija()
        {


            int izbor = 0;
            do
            {
                Console.WriteLine("=== Glavni meni ===");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestajem");
                Console.WriteLine("3. Rad sa korisnikom");
                Console.WriteLine("4. Rad sa dodatnom uslugom");
                Console.WriteLine("5. Rad sa salonom");
                Console.WriteLine("6. Rad sa akcijskom prodajom");
                Console.WriteLine("7. Rad sa prodajom namestaja");
                Console.WriteLine("0. Izlaz iz aplikacije");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 7);



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
                case 3:
                    IspisiMeniKorisnika();
                    break;
                case 4:
                    IspisiMeniDodatneUsluge();
                    break;
                case 5:
                    IspisiMeniSalona();
                    break;
                case 6:
                    IspsiMeniAkcija();
                    break;
                case 7:
                    IspisiMeniProdaje();
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
                Console.WriteLine("4. Pretrazi namestaj");
                Console.WriteLine("5. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 5);



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
                    PretragaNamestaja();
                    break;
                case 5:
                    IzbrisiNamestaj();
                    break;
                default:
                    break;
            }
        }


        private static void IzlistajNamestaj()
        {
            Console.WriteLine("=== Izlistavanje namestaja ===");
            var nam = Projekat.Instance.Namestaj;

            for (int i = 0; i < nam.Count; i++)
            {
                if (!nam[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{nam[i].Naziv}, cena: {nam[i].JedinicnaCena}");
                }
            }
            IspisiMeniNamestaja();
        }

        private static void DodavanjeNovogNamestaja()
        {

            var lnam = Projekat.Instance.Namestaj;

            Console.WriteLine("=== Dodavanje novog namestaja ===");
            var noviNamestaj = new Namestaj();
            noviNamestaj.Id = lnam.Count + 1;
            int idTipaNamestaja = 0;
            //noviNamestaj.Id = noviNamestaj.GetHashCode();

            Console.WriteLine("Unesite naziv: ");
            noviNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            noviNamestaj.JedinicnaCena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite sifru: ");
            noviNamestaj.Sifra = Console.ReadLine();

            Console.WriteLine("Unesite kolicinu: ");
            noviNamestaj.KolicinaUMagacinu = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite tip namestaja: ");
            idTipaNamestaja = int.Parse(Console.ReadLine());

            //var tipaNamestaja = Projekat.Instance.TipNamestaja;
            //TipNamestaja trazeniTipNamestaja = null;
            //da korisnik moze da unese tip namestaja koji postoji u listi


            var tipNamestaja = Projekat.Instance.TipNamestaja;
            TipNamestaja trazenitip;
            foreach (var tip in tipNamestaja)
            {
                if (tip.Id == idTipaNamestaja)
                {
                    trazenitip = tip;
                    noviNamestaj.TipNamestajaId = idTipaNamestaja;
                }
            }


            lnam.Add(noviNamestaj);
            GenericSerializer.Serialize<Namestaj>("namestaj.xml", lnam);

            IspisiMeniNamestaja();

        }

        private static void IzmenaNamestaja()
        {
            Namestaj trazeniNamestaj = null;
            int iDTrazenogNamestaja = 0;
            var nam = Projekat.Instance.Namestaj;

            do
            {
                Console.WriteLine("Unesite id namestaja: ");
                iDTrazenogNamestaja = int.Parse(Console.ReadLine());

                foreach (var namestaj in nam)
                {
                    if (namestaj.Id == iDTrazenogNamestaja)
                    {
                        trazeniNamestaj = namestaj;
                    }
                }

            } while (trazeniNamestaj == null);

            Console.WriteLine("Unesite novi naziv namestaja: ");
            trazeniNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite novu cenu namestaja: ");
            trazeniNamestaj.JedinicnaCena = double.Parse(Console.ReadLine());


            GenericSerializer.Serialize<Namestaj>("namestaj.xml", nam);

            IspisiMeniNamestaja();

        }

        private static void PretragaNamestaja()
        {

            int izbor = 0;

            do
            {
                Console.WriteLine("=== Pretraga namestaja ===");
                Console.WriteLine("1. Pretraga po nazivu");
                Console.WriteLine("2. Pretraga po sifri");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 2);


            
            switch (izbor)
            {
                case 0:
                    IspisiMeniNamestaja();
                    break;
                case 1:
                    PretragaPoNazivu();
                    break;
                case 2:
                    PretragaPoSifri();
                    break;
                default:
                    break;
            }
            
        }

        
        
        private static void PretragaPoNazivu()
        {

            var nam = Projekat.Instance.Namestaj;
            foreach (var namestaj in nam)
            {
                Console.WriteLine("Unesite naziv namestaja: ");
                if (Console.ReadLine() == namestaj.Naziv)
                {
                    for (int i = 0; i < nam.Count; i++)
                    {
                        if (!nam[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}.{nam[i].Naziv},cena:{nam[i].JedinicnaCena}");
                        }
                    }
                }

            }


        }

        private static void PretragaPoSifri()
        {
            var nam = Projekat.Instance.Namestaj;

            foreach (var namestaj in nam)
            {
                Console.WriteLine("Unesite sifru namestaja: ");
                if (Console.ReadLine() == namestaj.Sifra)
                {
                    for (int i = 0; i < nam.Count; i++)
                    {
                        if (!nam[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}.{nam[i].Naziv},cena:{nam[i].JedinicnaCena}");
                        }
                    }
                }

            }

        }

        
        private static void IzbrisiNamestaj()
        {
            Namestaj trazeniNamestaj = null;
            int iDTrazenogNamestaja = 0;
            var lnma = Projekat.Instance.Namestaj;

            Console.WriteLine("Unesite id namestaja: ");
            iDTrazenogNamestaja = int.Parse(Console.ReadLine());

            foreach (var namestaj in lnma)
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
                Console.WriteLine("4. Pretraga tipa namestaja");
                Console.WriteLine("5. Obrisi postojeci tip namestaja");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 5);


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
                    PretragaTipaNamestaja();
                    break;
                case 5:
                    IzbrisiTipNamestaj();
                    break;
                default:
                    break;
            }

        }


        private static void IzlistajTipNamestaj()
        {
            Console.WriteLine("=== Izlistavanje tipa namestaja ===");

            var tip = Projekat.Instance.TipNamestaja;

            for (int i = 0; i < tip.Count; i++)
            {
                if (!tip[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. naziv: {tip[i].Naziv}");
                }
            }

            IspisiMeniTipaNamestaja();
        }

        private static void DodavanjeNovogTipaNamestaja()
        {
            Console.WriteLine("=== Dodavanje tipa namestaja ===");

            var tip = Projekat.Instance.TipNamestaja;
            var noviTipNamestaj = new TipNamestaja();
            noviTipNamestaj.Id = tip.Count + 1;

            Console.WriteLine("Unesite naziv tipa namestaja: ");
            noviTipNamestaj.Naziv = Console.ReadLine();

            tip.Add(noviTipNamestaj);
            GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", tip);
            IspisiMeniTipaNamestaja();

        }

        private static void IzmenaTipaNamestaja()
        {

            TipNamestaja trazeniTipNamestaj = null;
            int iDTrazenogTipaNamestaja = 0;
            var tip = Projekat.Instance.TipNamestaja;

            do
            {
                Console.WriteLine("Unesite id tipa namestaja: ");
                iDTrazenogTipaNamestaja = int.Parse(Console.ReadLine());

                foreach (var tipNamestaja in tip)
                {
                    if (tipNamestaja.Id == iDTrazenogTipaNamestaja)
                    {
                        trazeniTipNamestaj = tipNamestaja;
                    }
                }

            } while (trazeniTipNamestaj == null);

            Console.WriteLine("Unesite novi naziv namestaja: ");
            trazeniTipNamestaj.Naziv = Console.ReadLine();


            GenericSerializer.Serialize<TipNamestaja>("tipoviNamestaja.xml", tip);
            IspisiMeniTipaNamestaja();

        }


        private static void PretragaTipaNamestaja()
        {


            int izbor = 0;

            do
            {
                Console.WriteLine("=== Pretraga tipa namestaja ===");
                Console.WriteLine("1. Pretraga tipa po nazivu");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 1);



            switch (izbor)
            {
                case 0:
                    IspisiMeniNamestaja();
                    break;
                case 1:
                    PretragaTipaPoNazivu();
                    break;
                default:
                    break;
            }

        }

        private static void PretragaTipaPoNazivu()
        {

            var tip = Projekat.Instance.TipNamestaja;

            foreach (var t in tip)
            {
                Console.WriteLine("Unesite naziv tipa namestaja: ");
                if (Console.ReadLine() == t.Naziv)
                {
                    for (int i = 0; i < tip.Count; i++)
                    {
                        if (!tip[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}.{tip[i].Naziv}");
                        }
                    }

                }
            }

        }



        private static void IzbrisiTipNamestaj()
        {

            TipNamestaja trazeniTipNamestaj = null;
            int iDTrazenogTipaNamestaja = 0;
            var tip = Projekat.Instance.TipNamestaja;

            Console.WriteLine("unesite id tipa namestaja: ");
            iDTrazenogTipaNamestaja = int.Parse(Console.ReadLine());

            foreach (var tipnamestaja in tip)
            {
                if (tipnamestaja.Id == iDTrazenogTipaNamestaja)
                {
                    tipnamestaja.Obrisan = true;
                }
            }

            IspisiMeniTipaNamestaja();

        }
        
        private static void IspisiMeniKorisnika()
        {

            {

                int izbor = 0;

                do
                {
                    Console.WriteLine("=== Meni korisnika ===");
                    Console.WriteLine("1. Izlisaj korisnike");
                    Console.WriteLine("2. Dodaj nove korisnoke");
                    Console.WriteLine("3. Izmeni postojece korisnike");
                    Console.WriteLine("4. Obrisi postojece korisnike");
                    Console.WriteLine("0. Povratak u glavni meni");

                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 4);


                switch (izbor)
                {
                    case 0:
                        IspisGlavnogMenija();
                        break;
                    case 1:
                        IzlistajKorisnike();
                        break;
                    case 2:
                        DodavanjeNovogKorisnika();
                        break;
                    case 3:
                        IzmenaKorisnika();
                        break;
                    case 4:
                        IzbrisiKorisnika();
                        break;
                    default:
                        break;
                }

            }

        }

        
        private static void IzlistajKorisnike()
        {
            Console.WriteLine("=== Izlistavanje korisnika ===");

            var lista = Projekat.Instance.Korisnik;

            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. ime: {lista[i].Ime} prezime: {lista[i].Prezime}");
                }
            }
            IspisiMeniKorisnika();

        }

        private static void DodavanjeNovogKorisnika()
        {
            Console.WriteLine("=== Dodavanje novog korisnika ===");

            var noviKorisnik = new Korisnik();
            var kori = Projekat.Instance.Korisnik;
            noviKorisnik.Id = kori.Count + 1;


            Console.WriteLine("Unesite ime novog korisnika: ");
            noviKorisnik.Ime = Console.ReadLine();


            Console.WriteLine("Unesite prezime novog korisnika: ");
            noviKorisnik.Prezime = Console.ReadLine();

            Console.WriteLine("Unesite korisnicko ime novog korisnika: ");
            noviKorisnik.KorisnickoIme = Console.ReadLine();

            Console.WriteLine("Unesite lozinku novog korisnika: ");
            noviKorisnik.Lozinka = Console.ReadLine();


            string nazivTipaKorisnika = "";
            Korisnik trazeniTipKorisnika = null;
           
            /*
            do
            {
                Console.WriteLine("Unesite tip korisnika: ");
                nazivTipaKorisnika = Console.ReadLine();
                foreach (var tipKorisnika in kori)
                {
                    if (tipKorisnika.TipKorisnika == nazivTipaKorisnika)
                    {
                        trazeniTipKorisnika = tipKorisnika;
                    }
                }
            } while (trazeniTipKorisnika == null);

            kori.Add(noviKorisnik);
            GenericSerializer.Serialize<Korisnik>("korisnik.xml", kori);
            IspisiMeniKorisnika();
            */

        }


        private static void IzmenaKorisnika()
        {
            var kori = Projekat.Instance.Korisnik;
            Korisnik trazeniKorisnik = null;
            int iDTrazenogKorisnika = 0;

            do
            {
                Console.WriteLine("Unesite id korisnika: ");
                iDTrazenogKorisnika = int.Parse(Console.ReadLine());

                foreach (var korisnik in kori)
                {
                    if (korisnik.Id == iDTrazenogKorisnika)
                    {
                        trazeniKorisnik = korisnik;
                    }
                }

            } while (trazeniKorisnik == null);

            Console.WriteLine("Unesite novo ime korisnika: ");
            trazeniKorisnik.Ime = Console.ReadLine();

            Console.WriteLine("Unesite novo prezime korisnika: ");
            trazeniKorisnik.Prezime = Console.ReadLine();

            Console.WriteLine("Unesite novo korisnicko ime korisnika: ");
            trazeniKorisnik.KorisnickoIme = Console.ReadLine();

            Console.WriteLine("Unesite novu sifru korisnika: ");
            trazeniKorisnik.Lozinka = Console.ReadLine();


            GenericSerializer.Serialize<Korisnik>("korisnik.xml", kori);
            IspisiMeniKorisnika();
        }

        private static void IzbrisiKorisnika()
        {
            var kori = Projekat.Instance.Korisnik;
            Korisnik trazeniKorisnik= null;
            int iDTrazenogKorisnika = 0;

            Console.WriteLine("Unesite id korisnika: ");
            iDTrazenogKorisnika = int.Parse(Console.ReadLine());

            foreach (var korisnik in kori)
            {
                if (korisnik.Id == iDTrazenogKorisnika)
                {
                    korisnik.Obrisan = true;
                }
            }

            GenericSerializer.Serialize<Korisnik>("korisnik.xml", kori);
            IspisiMeniKorisnika();
        }
        
        private static void IspisiMeniDodatneUsluge()
        {
            {
                int izbor = 0;

                do
                {
                    Console.WriteLine("=== Meni dodatne usluge ===");
                    Console.WriteLine("1. Izlisaj dodatne usluge");
                    Console.WriteLine("2. Dodaj novu uslugu");
                    Console.WriteLine("3. Izmeni postojecu uslugu");
                    Console.WriteLine("4. Obrisi postojecu uslugu");
                    Console.WriteLine("0. Povratak u glavni meni");

                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 4);


                switch (izbor)
                {
                    case 0:
                        IspisGlavnogMenija();
                        break;
                    case 1:
                        IzlistajUsluge();
                        break;
                    case 2:
                        DodavanjeNoveUsluge();
                        break;
                    case 3:
                        IzmenaDodatneUsluge();
                        break;
                    case 4:
                        IzbrisiDodatnuUslugu();
                        break;
                    default:
                        break;
                }

            }

        }

        private static void IzlistajUsluge()
        {

            Console.WriteLine("=== Izlistavanje usluga ===");
            var usluga = Projekat.Instance.DodatnaUsluga;

            for (int i = 0; i < usluga.Count; i++)
            {
                if (!usluga[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{usluga[i].Naziv},cena: {usluga[i].Cena}");
                }
            }

            IspisiMeniDodatneUsluge();

        }


        private static void DodavanjeNoveUsluge()
        {

            Console.WriteLine("=== Dodavanje nove usluge ===");

            var usluga = Projekat.Instance.DodatnaUsluga;
            var novaUsluga = new DodatnaUsluga();
            novaUsluga.Id = usluga.Count + 1;

            Console.WriteLine("Unesite naziv dodatne usluge: ");
            novaUsluga.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu dodatne usluge: ");
            novaUsluga.Cena = double.Parse(Console.ReadLine());

           

            usluga.Add(novaUsluga);
            GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", usluga);
            IspisiMeniTipaNamestaja();

            IspisiMeniDodatneUsluge();
        }


        private static void IzmenaDodatneUsluge()
        {

            DodatnaUsluga trazenaUsluga = null;
            int iDUsluge = 0;
            var usluge = Projekat.Instance.DodatnaUsluga;

            do
            {
                Console.WriteLine("Unesite id uslge: ");
                iDUsluge = int.Parse(Console.ReadLine());

                foreach (var usluga in usluge)
                {
                    if (usluga.Id == iDUsluge)
                    {
                        trazenaUsluga = usluga;
                    }
                }

            } while (trazenaUsluga == null);

            Console.WriteLine("Unesite naziv usluge: ");
            trazenaUsluga.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu usluge: ");
            trazenaUsluga.Cena = double.Parse(Console.ReadLine());

            IspisiMeniDodatneUsluge();
        }

        private static void IzbrisiDodatnuUslugu()
        {
            DodatnaUsluga trazenaUsluga = null;
            int iDUsluge = 0;
            var usluge = Projekat.Instance.DodatnaUsluga;

            Console.WriteLine("Unesite id usluge: ");
            iDUsluge = int.Parse(Console.ReadLine());

            foreach (var usluga in usluge)
            {
                if (usluga.Id == iDUsluge)
                {
                    usluga.Obrisan = true;
                }
            }

            IspisiMeniDodatneUsluge();

        }

        
        private static void IspisiMeniSalona()
        {
            
                int izbor = 0;

                do
                {
                    Console.WriteLine("=== Meni salona ===");
                    Console.WriteLine("1. Izlisaj salon");
                    Console.WriteLine("2. Izmeni postojeci salon");
                    Console.WriteLine("0. Povratak u glavni meni");

                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 2);


                switch (izbor)
                {
                    case 0:
                        IspisGlavnogMenija();
                        break;
                    case 1:
                        IzlistajSalon();
                        break;
                    case 2:
                        IzmeniSalon();
                        break;
                    default:
                        break;
                }

            
        }

        private static void IzlistajSalon()
        {
            Console.WriteLine("=== Izlistavanje salona ===");

            var salon = Projekat.Instance.Salon;

            for (int i = 0; i < salon.Count; i++)
            {
                if (!salon[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. naziv: {salon[i].Naziv}");
                }
            }
        }

        private static void IzmeniSalon()
        {
            Salon trazenaSalon = null;
            int iDSalona = 0;
            var salon = Projekat.Instance.Salon;

            do
            {
                Console.WriteLine("Unesite id salona: ");
                iDSalona = int.Parse(Console.ReadLine());

                foreach (var s in salon)
                {
                    if (s.Id == iDSalona)
                    {
                        trazenaSalon = s;
                    }
                }

            } while (trazenaSalon == null);

            Console.WriteLine("Unesite naziv salona: ");
            trazenaSalon.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite adresu salona: ");
            trazenaSalon.Adresa = Console.ReadLine();

            Console.WriteLine("Unesite telefon salona: ");
            trazenaSalon.Telefon = Console.ReadLine();

            Console.WriteLine("Unesite email salona: ");
            trazenaSalon.Email = Console.ReadLine();

            Console.WriteLine("Unesite internet adresu: ");
            trazenaSalon.InternetAdresa = Console.ReadLine();

            Console.WriteLine("Unesite pib salona: ");
            trazenaSalon.PIB = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite maticni broj salona: ");
            trazenaSalon.MaticniBroj = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite ziro racun salona: ");
            trazenaSalon.ZiroRacun = Console.ReadLine();

       
            GenericSerializer.Serialize<Salon>("salon.xml", salon);
            

            IspisiMeniSalona();
        }



        private static void IspsiMeniAkcija()
        {

            int izbor = 0;

            do
            {
                Console.WriteLine("=== Meni akcijske prodaje ===");
                Console.WriteLine("1. Izlisaj akciju");
                Console.WriteLine("2. Dodaj novu akciju");
                Console.WriteLine("3. Izmeni postojeci akciju");
                Console.WriteLine("4. Obrisi postojecu akciju");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);



            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajAkciju();
                    break;
                case 2:
                    DodajNovuAkciju();
                    break;
                case 3:
                    IzmenaAkcija();
                    break;
                case 4:
                    IzbrisiAkciju();
                    break;
                default:
                    break;
            }

        }



        private static void IzlistajAkciju()
        {

                Console.WriteLine("=== Izlistavanje akcijske pordaje ===");

                var akcija = Projekat.Instance.AkcijskaProdaja;

                for (int i = 0; i < akcija.Count; i++)
                {
                    if (!akcija[i].Obrisan)
                    {
                        Console.WriteLine($"{i + 1}. datum pocetka: {akcija[i].DatumPocetka}, datum zavrsetka: {akcija[i].DatumZavrsetka}");
                    }
                }

                IspsiMeniAkcija();
            }

            private static void DodajNovuAkciju()
            {
           
                Console.WriteLine("=== Dodavanje nove ackijske prodaje ===");

                var akcija = Projekat.Instance.AkcijskaProdaja;
                var novaAkcija = new AkcijskaProdaja();
                novaAkcija.Id = akcija.Count + 1;

                Console.WriteLine("Unesite popust: ");
                novaAkcija.Popust = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Unesite datum pocetka akcije: ");
                novaAkcija.DatumPocetka = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Unesite datum zavretka akcije: ");
                novaAkcija.DatumZavrsetka = DateTime.Parse(Console.ReadLine());


                akcija.Add(novaAkcija);
                GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", akcija);

                IspsiMeniAkcija();

            }

        private static void IzmenaAkcija()
        {
            throw new NotImplementedException();
        }
        private static void IzbrisiAkciju()
        {
            throw new NotImplementedException();
        }


        private static void IspisiMeniProdaje()
        {
            throw new NotImplementedException();
        }


    }
}