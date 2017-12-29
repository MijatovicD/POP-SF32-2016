-- seed.sql

INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Polica', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Regal', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Ugaona garnitura', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Krevet', 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(1, 'Ultra polica', 'UL1PO', 123.5, 2, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(2, 'Super sofa', 'SS2RE', 257.4, 4, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(3, 'Bracni krevet', 'BR3UG', 384.0, 8, 0);

INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) VALUES('Montiranje', 785.4, 0);
INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) VALUES('Sklapanje', 800.0, 0);
INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) VALUES('Tapaciranje', 937.0, 0);

INSERT INTO Salon (Naziv, Adresa, Telefon, Email, InternetAdresa, Pib, MaticniBroj, ZiroRacun) VALUES('FTNale', 'Trg Dositeja Obradovica 6', '021/345-248', 'fakultet@ftn.uns.ac.rs', 'www.ftn.uns.ac.rs', 32489624, 1896547896, 208-75982148-35);

INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) VALUES('Petar', 'Petrovic', 'pera12', '12pera', 'Administrator', 0);
INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) VALUES('Zika', 'Zikic', 'zika12', '12zika', 'Prodavac', 0);

INSERT INTO AkcijskaProdaja (DatumPocetka, Popust, DatumZavrsetka, NamestajId, Obrisan) VALUES('2017-08-11T00:00:00', 50, '2017-12-17T00:00:00', 1, 0);
INSERT INTO AkcijskaProdaja (DatumPocetka, Popust, DatumZavrsetka, NamestajId, Obrisan) VALUES('2017-04-05T09:35:00', 80, '2017-12-15T18:45:00', 2, 0);

INSERT INTO StavkaProdaje (NamestajId, Kolicina) VALUES(1, 1);
INSERT INTO StavkaProdaje (NamestajId, Kolicina, DodatnaUslugaId) VALUES(2, 2, 2);

INSERT INTO NaAkciji (NamestajId) VALUES (1)

INSERT INTO ProdajaNamestaja (DatumProdaje, BrojRacuna, Kupac, StavkeNamestajaId, StavkeUslugaId) VALUES ('12-15-2017', 4, 'Diki', 6038, 1)
INSERT INTO ProdajaNamestaja (DatumProdaje, BrojRacuna, Kupac, StavkeNamestajaId, StavkeUslugaId) VALUES ('12-17-2017', 4, 'Miki', 4, 2)

INSERT INTO StavkeNamestaja (IdProdaje, NamestajId, Kolicina) VALUES (1,1,5)
INSERT INTO StavkeNamestaja (IdProdaje, NamestajId, Kolicina) VALUES (2,2,3)

INSERT INTO StavkeUsluge (IdProdaje, UslugaId) VALUES (1,1)
INSERT INTO StavkeUsluge (IdProdaje, UslugaId) VALUES (2,2)