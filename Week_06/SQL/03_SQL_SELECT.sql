--use HastaneDb
--select * from Bolumler

--use HastaneDb
--select*from Doktorlar



---Filtreleme
--use HastaneDb
--select  adSoyad as'AD SOYAD', adres as ADRES from Doktorlar --ADRESS tek kelime oldu�u i�in t�krnak koymam�za gerek yok ama koyabiliriz

--select * from Doktorlar where id=5
--select * from Doktorlar where adSoyad='Tuna Sefer' --ad� tuna sefer olan� getirir
--select * from Doktorlar where NOT adSoyad='Tuna Sefer'  --�stteki ile ayn�
--select * from Doktorlar where adSoyad!='Tuna Sefer'  --buda tuna sefer hari� hepsini getirir
--select * from Doktorlar where id=3 or id=6

--select * from Doktorlar where bolumId=5 and adres='�zmir'

--select * from Doktorlar where id>6

--select * from Doktorlar where adres in('�stanbul','�zmir') -- adresin i�inde istanbul ve izmir varm� bakar

--select * from Doktorlar WHERE adSoyad like 'tut%' -- ne ile ba�l�yorsa
--select * from Doktorlar WHERE adSoyad like '%evgar' --- ne ile bitiyorsa
--select * from Doktorlar WHERE adSoyad like '%s%'  -- i�erisinde ge�iyorsa
--select * from Doktorlar WHERE adSoyad like '_e%' -- buda ikinci harfi e olanlar� getirdi
--select * from Doktorlar WHERE adSoyad like 'D_m%'-- iilk harfi D ikincisi ne olursa olsun 3.harfi M olanlar� getirir.




--------S�ralama

--select * from Doktorlar ORDER BY adSoyad --tabloyu defaul olarak ASC yani k���kten b�y��e gider
--select * from Doktorlar ORDER BY adSoyad DESC --tbuda b�y�kten k����e do�ru gider
--select * from Doktorlar order by adres 
--select * from Doktorlar order by adres , adSoyad DESC


-----------Hesaplama
--use KutuphaneDb
--select * from Kitaplar
--select MIN(sayfaSayisi) as 'En az sayfa say�s�' from Kitaplar
--select MAX(sayfaSayisi) as 'En y�ksek sayfa say�s�' from Kitaplar

--USE HastaneDb
--select count(*) from Doktorlar
--select count(bolumId) from Doktorlar -- parantez i�indeki verilen kolona g�re i�erisindeki dolu olan de�erleri getirir

--use KutuphaneDb
--select AVG(sayfaSayisi) from Kitaplar --sayfasayisi kolonunun ortalamas�n� al�r

--select SUM(stok) from Kitaplar --toplam�n� al�r

--select sum(stok*sayfaSayisi)from Kitaplar



----------STRING 
--use HastaneDb
--select LEN('Engin Niyazi Erg�l')
--select adSoyad,len(adSoyad) as'Ad Soyad uzunlu�u' from Doktorlar

--select adSoyad, 
--	left(adSoyad,3)as'ilk 3 karakter',
--	len(adSoyad)as'uzunluk' 
--from Doktorlar

--select
--	adSoyad,
--	UPPER(adSoyad) as'B�Y�K',
--	LOWER(adSoyad)as'k���K'
--from Doktorlar

--select
--	replace('Hasancan G�zel','n','Merhaba') -- yaz�n�n i�inde ge�en her n harfi i�in merhaba yazd�rd�k


--select  lower(replace('Hasancan G�zel',' ','')) + '@benimfirmam.com'  -- + birle�tirme i�in kulland�k

--select adSoyad,replace(lower(adSoyad),' ','')+'@firma.com' as'mail adresi' from Doktorlar

--Sercan Furkan ad�nda, Amasyada ya�ayan b�l�m� 3 olan doktoru kaydedecek sorguyu yaz�n�z
--insert into Doktorlar values('Sercan Furkan','Amasya',3)
--select * from Doktorlar


--------G�ncelleme---------
--Update Doktorlar set adSoyad='Sercan Ahmet Furkan' where id=12  --where ko�ulunu girmezsek t�m tablodaki adsoyad� g�ncller
--select * from Doktorlar


--use KutuphaneDb
--update Kitaplar set sayfaSayisi=sayfaSayisi*1.2
--select *from Kitaplar

-------------S�LME------------
--use HastaneDb
--Delete from Doktorlar where id=6
--select * from Doktorlar

--delete from Doktorlar where bolumId IS NULL  -- nul de�er sileceksek IS yazmam�z laz�m =i�e yaramaz
--SELECT*FROM Doktorlar











