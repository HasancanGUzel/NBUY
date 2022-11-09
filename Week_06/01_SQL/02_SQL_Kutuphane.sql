/* 
	1)Kütüphane Adýnda bir veritabaný oluþturunuz
	2)Veritabaný aþaðýdaki  tablolar olsun
		Turler
		Yazarlar
		Yayinevleri
		Uyeler
		Kitaplar
		OduncIslemleri
	3)Yeteri kadar örnek veri giriþide yapýnýz
*/        
--------on delete cascade  ---------------- 
--------sildirmez

--------- turId int default 1 .......foreign key var............on delete set default------------------------- 
--buda siler ama silineni default deðer olarak atar
--bunu içinde tabloda turId kýsmýna girip allow nulls iþaretli olmasý lazým ve içeriðine default kýsmýný 1 yapmamýz lazým

---turId int .....foreign key var arada............  on delete set null 
---bu satýrda veri silindiði zaman deðerini  NULL yapar.


--bu kodlarý elle yazmak yerine tablonun tasarým kýsmýndan istediðimiz kolona giderek bu kolonun properties lerinden table designer içeriðinden yapýlýr. 


use master
GO

Drop database if exists Kutuphane  
GO

Create database Kutuphane
GO

USE Kutuphane
go
--------------------------------türler----------------------
Create table Turler(
	id int not null primary key identity(1,1),
	ad nvarchar(50) not null
)
Go
insert into Turler values
	('Macera'),
	('Romantik'),
	('Polisiye'),
	('Bilim-Kurgu'),
	('Aksiyon'),
	('Tarih')
GO
---------------------------------Yazarlar------------------
Create table Yazarlar (
	id int not null primary key identity(1,1),
	adSoyad nvarchar(50) not null,
	Cinsiyet char(1) not null,
	yas int not null
)
GO

insert into Yazarlar values
	('Sefa Tavukçu','E',22),
	('Ahmet Kaçar','E',35),
	('Ayþe Yalan','K',33),
	('Arzu Yumuþak','K',59),
	('Onur Kemal','E',55)
GO
----------------------------------Yayýnevleri-----------------
Create table Yayinevleri (
	id int not null primary key identity(1,1),
	ad nvarchar(50) not null,
	adres nvarchar(50) 
	
)
GO

insert into Yayinevleri values
	('pelikan','Ýstanbul'),
	('Morpa','Ýzmir'),
	('FEM',''),
	('Mars','Ankara'),
	('Jüpiter','')
GO

------------------------------------------Uyeler-------------------
Create table Uyeler (
	id int not null primary key identity(1,1),
	adSoyad nvarchar(50) not null,
	Cinsiyet char(1) not null,
	yas int not null
)
GO

insert into Uyeler values
	('Mustafa Kemal','E',22),
	('Fatih Terim','E',75),
	('Okan Buruk','E',50),
	('Senem Kumar','K',22),
	('Esra Yüksel','K',23),
	('Hamide Üçtepe','K',21)
GO
-----------------------------Kitaplar----------------------

Create table Kitaplar (
	id int not null primary key identity(1,1),
	ad nvarchar(50) not null,
	yayineviId int not null,
	yazarId int not null,
	--turId int not null,
	foreign key (yayineviId) references Yayinevleri(id),
	foreign key (yazarId) references Yazarlar(id)
)
GO

insert into Kitaplar values
	('Kürk Mantolu Madonna',1,1),
	('Devlet Ana',2,2),
	('Sefiller',3,3),
	('Sherlock Holmes',4,4),
	('Harry Potter',5,5),
	('Savaþ Atý',1,5),
	('Ruhi Mücerret',2,3),
	('Küçük Prens',3,4),
	('Suç ve Ceza ',1,4),
	('Hayvan Çiftliði',2,5)
GO

-------Çoka çok KitTur tablosu
Create table KitapTur(
	kitapId int not null,
	turId int not null,
	foreign key(kitapId) references Kitaplar(id),
	foreign key(turId) references Turler(id)
)
GO

insert into KitapTur values
	(1,1),
	(1,2),
	(1,3),
	(2,1),
	(2,5),
	(2,5),
	(2,3),
	(5,6),
	(3,6),
	(3,3),
	(4,1),
	(4,6),
	(10,5),
	(7,2),
	(9,1),
	(6,3),
	(3,6),
	(6,4)
GO
------Odunç islemleri-------------
Create table OduncIslem(
	id int not null primary key identity(1,1),
	
	uyeId int not null,
	kitapId int not null,
	tarih date not null,
	foreign key(uyeId) references Uyeler(id),
	foreign key(kitapId) references Kitaplar(id)
)
GO

insert into OduncIslem values
	(1,1,'2022-05-09'),
	(2,2,'2022-06-09'),
	(3,3,'2022-08-09'),
	(4,4,'2022-07-09'),
	(5,5,'2022-09-09'),
	(6,6,'2022-01-09'),
	(6,10,'2022-03-02'),
	(2,9,'2022-02-09')

GO



