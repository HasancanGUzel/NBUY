
USE SampleDb

/*
		urunler tablosu
		urunID
		urunAd
		StokMiktari
		UrnFiyat

		bo� b�rak�lamas�n id primary key

*/

	CREATE TABLE Urunler(
		id int not null PRIMARY KEY IDENTITY(1,1),
		urunAd nvarchar(50)  not null,
		stokMiktari int  not null,
		urunFiyat money  not null,
	)

	

