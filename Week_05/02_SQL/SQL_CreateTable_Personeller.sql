Create database SirketDb2  --VERÝTABANI YARATILDIKTAN SONRA ALT TARAFA GEÇÝYOR GO ÝSE VERÝTABANI OLUÞTURULMADAN ALTA GEÇMESÝN DÝYE
GO

	USE SirketDb2

Create table Departmanlar(
		id int not null PRIMARY KEY IDENTITY(1,1),
		ad nvarchar(MAX) not null,

	)

		--tablomuza veri ekliyoruz
insert into Departmanlar(ad) values ('muhasebe'),('teknik servis'),('satýþ'),('ÝK'),('yönetim')

--insert into Departmanlar(ad) values   --böylede yazýlabilir
--('muhasebe'),
--('teknik servis'),
--('satýþ'),
--('ÝK'),
--('yönetim')




/*
		iþçi muhasebe uzmaný, satýþçý,ik uzmaný, ik stajyeri, yönetici, yönetici yardýmcýsý
*/
--------------------------------------------
Create table Unvanlar(
		id int not null PRIMARY KEY IDENTITY(1,1),
		ad nvarchar(MAX) not null,
	)


insert into Unvanlar(ad) values
	('iþçi'),
	('muhasebe uzmaný'),
	('satýþçý'),
	('ik uzmaný'),
	('ik stajyeri'),
	('yönetici'),
	('yönetici yardýmcýsý')



-------------------------------------------------------

Create table iller(
		id char(2) not null PRIMARY KEY,
		ad nvarchar(30) not null,
	)

	insert into iller(id,ad) values
	('34','Ýstanbul'),
	('06','Ankara'),
	('35','Ýzmir'),
	('58','Sivas'),
	('41','Ýzmit')

	---------------------------------

Create table ilceler(
		id int primary key not null identity(1,1),
		ad nvarchar(30) not null,
		ilId char(2) not null,
		foreign key(ilId) references iller(id)
	)

insert into ilceler(ad,ilId) values
	('Kadýköy','34'),
	('Beþiktaþ','34'),
	('Konak','35'),
	('Avcýlar','34'),
	('Karþýyaka','35'),
	('Yeni mahalle','06'),
	('Çankaya','06'),
	('Suþehri','58')


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
	('Hasancan','Güzel',0,'1999-05-15',1,'2021-11-10',1,1,12500),
	('Sefa','Tavukçu',1,'2015-06-08',2,'2021-11-10',2,2,15000),
	('Alican','Kabak',0,'1985-10-5',3,'2021-11-10',3,3,50000),
	('Fatih','Terim',0,'1975-05-13',4,'2021-11-10',4,4,8000),
	('Burak','Sever',0,'1993-01-10',5,'2021-11-10',1,5,5000),
	('Ayþe','Kömürcü',1,'1973-05-18',6,'2021-11-10',2,6,5500),
	('Güray','Þen',0,'1986-08-18',7,'2021-11-10',2,7,20000),
	('Arzu','Daþdan',1,'2002-08-30',2,'2021-11-10',5,1,18000)
	
	



Create table Projeler(
		id int primary key not null identity(1,1),
		ad nvarchar(50) not null,
		baslamaTarihi date not null,
		planlamaTarihi date not null,
	)

insert into Projeler(ad,baslamaTarihi,planlamaTarihi)values
	('Mutlu Çocuklar','2022-5-5','2022-8-5'),
	('Temiz Üsküdar','2022-5-5','2022-8-5'),
	('Kirli Kadýköy ','2022-5-5','2022-8-5'),
	('Haydi gençler elele','2022-5-5','2022-8-5')


