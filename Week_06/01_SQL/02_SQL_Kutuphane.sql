/* 
	1)K�t�phane Ad�nda bir veritaban� olu�turunuz
	2)Veritaban� a�a��daki  tablolar olsun
		Turler
		Yazarlar
		Yayinevleri
		Uyeler
		Kitaplar
		OduncIslemleri
	3)Yeteri kadar �rnek veri giri�ide yap�n�z
*/        
--------on delete cascade  ---------------- 
--------sildirmez

--------- turId int default 1 .......foreign key var............on delete set default------------------------- 
--buda siler ama silineni default de�er olarak atar
--bunu i�inde tabloda turId k�sm�na girip allow nulls i�aretli olmas� laz�m ve i�eri�ine default k�sm�n� 1 yapmam�z laz�m

---turId int .....foreign key var arada............  on delete set null 
---bu sat�rda veri silindi�i zaman de�erini  NULL yapar.


--bu kodlar� elle yazmak yerine tablonun tasar�m k�sm�ndan istedi�imiz kolona giderek bu kolonun properties lerinden table designer i�eri�inden yap�l�r. 


use master
GO

Drop database if exists Kutuphane  
GO

Create database Kutuphane
GO

USE Kutuphane
go
--------------------------------t�rler----------------------
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
	('Sefa Tavuk�u','E',22),
	('Ahmet Ka�ar','E',35),
	('Ay�e Yalan','K',33),
	('Arzu Yumu�ak','K',59),
	('Onur Kemal','E',55)
GO
----------------------------------Yay�nevleri-----------------
Create table Yayinevleri (
	id int not null primary key identity(1,1),
	ad nvarchar(50) not null,
	adres nvarchar(50) 
	
)
GO

insert into Yayinevleri values
	('pelikan','�stanbul'),
	('Morpa','�zmir'),
	('FEM',''),
	('Mars','Ankara'),
	('J�piter','')
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
	('Esra Y�ksel','K',23),
	('Hamide ��tepe','K',21)
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
	('K�rk Mantolu Madonna',1,1),
	('Devlet Ana',2,2),
	('Sefiller',3,3),
	('Sherlock Holmes',4,4),
	('Harry Potter',5,5),
	('Sava� At�',1,5),
	('Ruhi M�cerret',2,3),
	('K���k Prens',3,4),
	('Su� ve Ceza ',1,4),
	('Hayvan �iftli�i',2,5)
GO

-------�oka �ok KitTur tablosu
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
------Odun� islemleri-------------
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



