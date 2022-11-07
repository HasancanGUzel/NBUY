
        --Hangi veritabanýnýnda iþlem yapacaðýmýz seçmemiz lazým
  USE SampleDb

			--TABLO OLUÞTURMA
  CREATE TABLE Bolumler(
		id INT	NOT NULL,
		ad NVARCHAR(20) NULL,
)


		--tablo silme iþlemi
DROP TABLE  Bolumler

  CREATE TABLE Bolumler(
		id INT	NOT NULL PRIMARY KEY IDENTITY(1,1),
		ad NVARCHAR(30),
		aciklama NVARCHAR(MAX)
)



