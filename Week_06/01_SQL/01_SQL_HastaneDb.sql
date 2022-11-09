use master
GO

Drop database if exists HastaneDb  -- hastnane veritaban�m�z varsa ilk �nce siliyor sonra tekrardan olu�turuyor
GO

Create database HastaneDb
GO


use HastaneDb
go


--Hastalar tablosu
Create table Hastalar(
	id int not null primary key identity(1,1),
	adSoyad nvarchar(50) not null,
	cinsiyet char(1) not null,
	adres nvarchar(50),
	telefon char(11)
)
GO

insert into Hastalar (adSoyad,cinsiyet,adres) values
	('Erencan Gemirli','E','�stanbul'),
	('Selin Fergen�','K','Ankara'),
	('Sadi Kulo�lu','E','�zmir'),
	('Ne�e Kalabal�k','K','�stanbul'),
	('Sevda A�alar','K','�zmir'),
	('Nora Ta�kesen','K','Ankara'),
	('Emma �eto�lu','K','�stanbul'),
	('Kerem S�zc�','E','Ankara'),
	('Suat Tartar','E','�zmir')
GO


--B�L�MLER TABLOSU
Create table Bolumler(
	id int not null primary key identity(1,1),
	ad nvarchar(30) not null
)
GO
insert into Bolumler values
	('Dahiliye'),('Norloji'),('Ortopedi'),	
	('Di�'),('Peritodontoloji'),('Genel cerrahi')
GO

--DOKTORLAR TABLOSU

create table Doktorlar(
	id int not null primary key identity(1,1),
	adSoyad nvarchar(50) not null,
	adres nvarchar(50),
	bolumId int,
	foreign key (bolumId) references Bolumler(id)
)
GO
insert into Doktorlar values
	('Ali ','�stanbul',1),
	('Demet Evgar ','Bursa',2),
	('Sedat kanar ','�stanbul',3),
	('Ferhunde Han�m ','�zmir',1),
	('Zafer Kimki ','Ankara',2),
	('Hale Elveren ','�stanbul',3),
	('Tuna Sefer ','Ankara',4),
	('Kevser Tutku ','�stanbul',4),
	('Tutkum Kap��mak Tutku ','�zmir',5),
	('�sa Canova ','�zmir',5),
	('Tu��e B�l�nmez ','�stanbul',NULL)
GO
--yukar�daki insert into nun son sat�r�n�n alternatifi buras�
--insert into Doktorlar (adSoyad,adres)values
--	('Tu��e B�l�nmez ','�stanbul')
--GO

