USE SampleDb

CREATE TABLE Calisanlar(
	id INT NOT NULL IDENTITY(1,1),
	tcNo char(11) not null,
	adSoyad nvarchar(50) not null,
	cinsiyet bit not null,
	bolumId int not null,
	PRIMARY KEY(id),--id yi ayný satýrda deðilde sonradan primary key yaptýk
	FOREIGN KEY (bolumId) REFERENCES Bolumler(id)    --burda bolum tablomuz vardý ve biz o bolum tablosuyla baðlantý kurmak için buraya bolumId tanýmlaýdk ve burdaki bolumId ye foreign key verip bolum tablosundaki id yle birleþtirdik

)


--DROP TABLE Calisanlar