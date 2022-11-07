USE SampleDb

CREATE TABLE Calisanlar(
	id INT NOT NULL IDENTITY(1,1),
	tcNo char(11) not null,
	adSoyad nvarchar(50) not null,
	cinsiyet bit not null,
	bolumId int not null,
	PRIMARY KEY(id),--id yi ayn� sat�rda de�ilde sonradan primary key yapt�k
	FOREIGN KEY (bolumId) REFERENCES Bolumler(id)    --burda bolum tablomuz vard� ve biz o bolum tablosuyla ba�lant� kurmak i�in buraya bolumId tan�mla�dk ve burdaki bolumId ye foreign key verip bolum tablosundaki id yle birle�tirdik

)


--DROP TABLE Calisanlar