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