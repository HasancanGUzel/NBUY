
        --Hangi veritaban�n�nda i�lem yapaca��m�z se�memiz laz�m
  USE SampleDb

			--TABLO OLU�TURMA
  CREATE TABLE Bolumler(
		id INT	NOT NULL,
		ad NVARCHAR(20) NULL,
)


		--tablo silme i�lemi
DROP TABLE  Bolumler

  CREATE TABLE Bolumler(
		id INT	NOT NULL PRIMARY KEY IDENTITY(1,1),
		ad NVARCHAR(30),
		aciklama NVARCHAR(MAX)
)



