Create database SirketDb2  --VER�TABANI YARATILDIKTAN SONRA ALT TARAFA GE��YOR GO �SE VER�TABANI OLU�TURULMADAN ALTA GE�MES�N D�YE
GO

	USE SirketDb2

Create table Departmanlar(
		id int not null PRIMARY KEY IDENTITY(1,1),
		ad nvarchar(MAX) not null,

	)

		--tablomuza veri ekliyoruz
insert into Departmanlar(ad) values ('muhasebe'),('teknik servis'),('sat��'),('�K'),('y�netim')

--insert into Departmanlar(ad) values   --b�ylede yaz�labilir
--('muhasebe'),
--('teknik servis'),
--('sat��'),
--('�K'),
--('y�netim')




/*
		i��i muhasebe uzman�, sat����,ik uzman�, ik stajyeri, y�netici, y�netici yard�mc�s�
*/
--------------------------------------------
Create table Unvanlar(
		id int not null PRIMARY KEY IDENTITY(1,1),
		ad nvarchar(MAX) not null,
	)


insert into Unvanlar(ad) values
	('i��i'),
	('muhasebe uzman�'),
	('sat����'),
	('ik uzman�'),
	('ik stajyeri'),
	('y�netici'),
	('y�netici yard�mc�s�')



-------------------------------------------------------

Create table iller(
		id char(2) not null PRIMARY KEY,
		ad nvarchar(30) not null,
	)

	insert into iller(id,ad) values
	('34','�stanbul'),
	('06','Ankara'),
	('35','�zmir'),
	('58','Sivas'),
	('41','�zmit')

	---------------------------------

Create table ilceler(
		id int primary key not null identity(1,1),
		ad nvarchar(30) not null,
		ilId char(2) not null,
		foreign key(ilId) references iller(id)
	)

insert into ilceler(ad,ilId) values
	('Kad�k�y','34'),
	('Be�ikta�','34'),
	('Konak','35'),
	('Avc�lar','34'),
	('Kar��yaka','35'),
	('Yeni mahalle','06'),
	('�ankaya','06'),
	('Su�ehri','58')


Create table Personeller(
		id int primary key not null identity(1,1),
		ad nvarchar(25) not null,
		soyAd nvarchar(25) not null,
		cinsiyet bit not null,
		dogumTarihi date not null,
		ilceId int not null,
		isebaslamaTarihi date not null,
		departmanId int not null,
		unvanId int not null,
		maas money not null,
		foreign key(ilceId) references ilceler(id),
		foreign key(departmanId) references Departmanlar(id),
		foreign key(unvanId) references Unvanlar(id)
	)

	insert into Personeller(ad,soyad,cinsiyet,dogumTarihi,ilceId,isebaslamaTarihi,departmanId,unvanId,maas) values
	('Hasancan','G�zel',0,'1999-05-15',1,'2021-11-10',1,1,12500),
	('Sefa','Tavuk�u',1,'2015-06-08',2,'2021-11-10',2,2,15000),
	('Alican','Kabak',0,'1985-10-5',3,'2021-11-10',3,3,50000),
	('Fatih','Terim',0,'1975-05-13',4,'2021-11-10',4,4,8000),
	('Burak','Sever',0,'1993-01-10',5,'2021-11-10',1,5,5000),
	('Ay�e','K�m�rc�',1,'1973-05-18',6,'2021-11-10',2,6,5500),
	('G�ray','�en',0,'1986-08-18',7,'2021-11-10',2,7,20000),
	('Arzu','Da�dan',1,'2002-08-30',2,'2021-11-10',5,1,18000)
	
	



Create table Projeler(
		id int primary key not null identity(1,1),
		ad nvarchar(50) not null,
		baslamaTarihi date not null,
		planlamaTarihi date not null,
	)

insert into Projeler(ad,baslamaTarihi,planlamaTarihi)values
	('Mutlu �ocuklar','2022-5-5','2022-8-5'),
	('Temiz �sk�dar','2022-5-5','2022-8-5'),
	('Kirli Kad�k�y ','2022-5-5','2022-8-5'),
	('Haydi gen�ler elele','2022-5-5','2022-8-5')


