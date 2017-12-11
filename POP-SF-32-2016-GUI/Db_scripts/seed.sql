-- seed.sql

INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Polica', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Regal', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Ugaona garnitura', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Krevet', 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(1, 'Ultra polica', 'UL1PO', 123.5, 2, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(2, 'Super sofa', 'SS2RE', 257.4, 4, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) VALUES(3, 'Bracni krevet', 'BR3UG', 384.0, 8, 0);