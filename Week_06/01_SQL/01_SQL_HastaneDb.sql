use master
GO

Drop database if exists HastaneDb  -- hastnane veritabanýmýz varsa ilk önce siliyor sonra tekrardan oluþturuyor
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
	('Erencan Gemirli','E','Ýstanbul'),
	('Selin Fergenç','K','Ankara'),
	('Sadi Kuloðlu','E','Ýzmir'),
	('Neþe Kalabalýk','K','Ýstanbul'),
	('Sevda Aðalar','K','Ýzmir'),
	('Nora Taþkesen','K','Ankara'),
	('Emma Çetoðlu','K','Ýstanbul'),
	('Kerem Sözcü','E','Ankara'),
	('Suat Tartar','E','Ýzmir')
GO


--BÖLÜMLER TABLOSU
Create table Bolumler(
	id int not null primary key identity(1,1),
	ad nvarchar(30) not null
)
GO
insert into Bolumler values
	('Dahiliye'),('Norloji'),('Ortopedi'),	
	('Diþ'),('Peritodontoloji'),('Genel cerrahi')
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
	('Ali ','Ýstanbul',1),
	('Demet Evgar ','Bursa',2),
	('Sedat kanar ','Ýstanbul',3),
	('Ferhunde Haným ','Ýzmir',1),
	('Zafer Kimki ','Ankara',2),
	('Hale Elveren ','Ýstanbul',3),
	('Tuna Sefer ','Ankara',4),
	('Kevser Tutku ','Ýstanbul',4),
	('Tutkum Kapýþmak Tutku ','Ýzmir',5),
	('Ýsa Canova ','Ýzmir',5),
	('Tuðçe Bölünmez ','Ýstanbul',NULL)
GO
--yukarýdaki insert into nun son satýrýnýn alternatifi burasý
--insert into Doktorlar (adSoyad,adres)values
--	('Tuðçe Bölünmez ','Ýstanbul')
--GO

