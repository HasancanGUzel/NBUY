
						--SATIÞ BÝLGÝLERÝNÝ TUTAN TABLO YAPACAÐIZ
USE SampleDb
Create table Satislar(
	id int not null PRIMARY KEY IDENTITY(1,1),
	urunId int not null,
	calisanId int not null,
	adet int not null,
	fiyat money not null,
	tarih datetime not null,
	FOREIGN KEY(urunId) REFERENCES Urunler(id),
	FOREIGN KEY(calisanId) REFERENCES Calisanlar(id)
)
--yyyy--aa--gg sqlde default olarak