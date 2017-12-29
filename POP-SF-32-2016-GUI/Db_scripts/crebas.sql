--crebas.sql

CREATE TABLE TipNamestaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
)
GO
CREATE TABLE Namestaj(
	Id INT PRIMARY KEY IDENTITY(1,1),
	TipNamestajaId INT,
	Naziv VARCHAR(100),
	Sifra VARCHAR(20),
	Cena NUMERIC(9,2),
	Kolicina SMALLINT,
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)
);
GO
CREATE TABLE DodatnaUsluga(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80),
	Cena NUMERIC(9,2),
	Obrisan BIT
);
GO
CREATE TABLE Korisnik(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Ime VARCHAR(30) NOT NULL,
	Prezime VARCHAR(30) NOT NULL,
	KorisnickoIme VARCHAR(30) NOT NULL,
	Lozinka VARCHAR(30) NOT NULL,
	TipKorisnika VARCHAR(30) NOT NULL,
	Obrisan BIT
);
GO
CREATE TABLE Salon(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(30) NOT NULL,
	Adresa VARCHAR(30) NOT NULL,
	Telefon VARCHAR(20) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	InternetAdresa VARCHAR(20) NOT NULL,
	Pib INT NOT NULL,
	MaticniBroj INT NOT NULL,
	ZiroRacun VARCHAR(20) NOT NULL
);
GO
CREATE TABLE AkcijskaProdaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DatumPocetka DATETIME NOT NULL,
	Popust DECIMAL NOT NULL,
	DatumZavrsetka DATETIME NOT NULL,
	NamestajId INT NOT NULL,
	Obrisan BIT,
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id) 
);
GO
CREATE TABLE StavkaProdaje(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Kolicina INT NOT NULL,
	NamestajId INT NOT NULL,
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id) 
);
GO
CREATE TABLE NaAkciji(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NamestajId INT,
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id)
);
GO
CREATE TABLE ProdajaNamestaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DatumProdaje DATETIME,
	BrojRacuna INT,
	Kupac VARCHAR(30),
	StavkeNamestajaId INT,
	StavkeUslugaId INT,
	FOREIGN KEY (StavkeNamestajaId) REFERENCES dbo.StavkeNamestaja(Id),
	FOREIGN KEY (StavkeUslugaId) REFERENCES dbo.StavkeUsluge(Id)
);
GO
CREATE TABLE StavkeNamestaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdProdaje INT,
	NamestajId INT,
	Kolicina INT,
	FOREIGN KEY (NamestajId) REFERENCES dbo.Namestaj(Id),
	FOREIGN KEY (IdProdaje) REFERENCES dbo.ProdajaNamestaja(Id)
);
GO
CREATE TABLE StavkeUsluge(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdProdaje INT,
	UslugaId INT,
	FOREIGN KEY (UslugaId) REFERENCES dbo.DodatnaUsluga(Id),
	FOREIGN KEY (IdProdaje) REFERENCES dbo.ProdajaNamestaja(Id)
);
ALTER TABLE dbo.Namestaj ADD AkcijaId INT NOT NULL FOREIGN KEY (AkcijaId) REFERENCES AkcijskaProdaja(Id) DEFAULT 1

DROP TABLE dbo.StavkaProdaje

ALTER TABLE dbo.ProdajaNamestaja ADD StavkeNamestajaId INT FOREIGN KEY (StavkeNamestajaId) REFERENCES dbo.StavkeNamestaja(Id) DEFAULT 1
ALTER TABLE dbo.ProdajaNamestaja ADD StavkeUslugaId INT FOREIGN KEY (StavkeUslugaId) REFERENCES dbo.StavkeUsluge(Id) DEFAULT 1

ALTER TABLE dbo.ProdajaNamestaja ADD CONSTRAINT StavkaNamestajaId FOREIGN KEY (StavkeNamestajaId) REFERENCES dbo.StavkeNamestaja(Id)
ALTER TABLE dbo.ProdajaNamestaja ADD CONSTRAINT StavkeUslugaId FOREIGN KEY (StavkeUslugaId) REFERENCES dbo.StavkeUsluge(Id)

ALTER TABLE dbo.StavkeNamestaja DROP CONSTRAINT FK__StavkeNam__IdPro__08B54D69
ALTER TABLE dbo.StavkeUsluge DROP CONSTRAINT FK__StavkeUsl__IdPro__0C85DE4D

ALTER TABLE dbo.ProdajaNamestaja DROP CONSTRAINT FK__ProdajaNa__Stavk__2B0A656D
ALTER TABLE dbo.ProdajaNamestaja DROP CONSTRAINT FK__ProdajaNa__Stavk__2BFE89A6
ALTER TABLE dbo.ProdajaNamestaja DROP COLUMN StavkeNamestajaId
ALTER TABLE dbo.ProdajaNamestaja DROP COLUMN StavkeUslugaId

ALTER TABLE dbo.NaAkciji ADD Obrisan BIT
ALTER TABLE dbo.NaAkciji ADD AkcijaId INT FOREIGN KEY (AkcijaId) REFERENCES dbo.AkcijskaProdaja(Id)

ALTER TABLE dbo.ProdajaNamestaja ADD UkupanIznos NUMERIC(9,2) NOT NULL DEFAULT 0