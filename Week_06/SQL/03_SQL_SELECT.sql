--use HastaneDb
--select * from Bolumler

--use HastaneDb
--select*from Doktorlar



---Filtreleme
--use HastaneDb
--select  adSoyad as'AD SOYAD', adres as ADRES from Doktorlar --ADRESS tek kelime olduðu için týkrnak koymamýza gerek yok ama koyabiliriz

--select * from Doktorlar where id=5
--select * from Doktorlar where adSoyad='Tuna Sefer' --adý tuna sefer olaný getirir
--select * from Doktorlar where NOT adSoyad='Tuna Sefer'  --üstteki ile ayný
--select * from Doktorlar where adSoyad!='Tuna Sefer'  --buda tuna sefer hariç hepsini getirir
--select * from Doktorlar where id=3 or id=6

--select * from Doktorlar where bolumId=5 and adres='Ýzmir'

--select * from Doktorlar where id>6

--select * from Doktorlar where adres in('Ýstanbul','Ýzmir') -- adresin içinde istanbul ve izmir varmý bakar

--select * from Doktorlar WHERE adSoyad like 'tut%' -- ne ile baþlýyorsa
--select * from Doktorlar WHERE adSoyad like '%evgar' --- ne ile bitiyorsa
--select * from Doktorlar WHERE adSoyad like '%s%'  -- içerisinde geçiyorsa
--select * from Doktorlar WHERE adSoyad like '_e%' -- buda ikinci harfi e olanlarý getirdi
--select * from Doktorlar WHERE adSoyad like 'D_m%'-- iilk harfi D ikincisi ne olursa olsun 3.harfi M olanlarý getirir.




--------Sýralama

--select * from Doktorlar ORDER BY adSoyad --tabloyu defaul olarak ASC yani küçükten büyüðe gider
--select * from Doktorlar ORDER BY adSoyad DESC --tbuda büyükten küçüðe doðru gider
--select * from Doktorlar order by adres 
--select * from Doktorlar order by adres , adSoyad DESC


-----------Hesaplama
--use KutuphaneDb
--select * from Kitaplar
--select MIN(sayfaSayisi) as 'En az sayfa sayýsý' from Kitaplar
--select MAX(sayfaSayisi) as 'En yüksek sayfa sayýsý' from Kitaplar

--USE HastaneDb
--select count(*) from Doktorlar
--select count(bolumId) from Doktorlar -- parantez içindeki verilen kolona göre içerisindeki dolu olan deðerleri getirir

--use KutuphaneDb
--select AVG(sayfaSayisi) from Kitaplar --sayfasayisi kolonunun ortalamasýný alýr

--select SUM(stok) from Kitaplar --toplamýný alýr

--select sum(stok*sayfaSayisi)from Kitaplar



----------STRING 
--use HastaneDb
--select LEN('Engin Niyazi Ergül')
--select adSoyad,len(adSoyad) as'Ad Soyad uzunluðu' from Doktorlar

--select adSoyad, 
--	left(adSoyad,3)as'ilk 3 karakter',
--	len(adSoyad)as'uzunluk' 
--from Doktorlar

--select
--	adSoyad,
--	UPPER(adSoyad) as'BÜYÜK',
--	LOWER(adSoyad)as'kÜÇÜK'
--from Doktorlar

--select
--	replace('Hasancan Güzel','n','Merhaba') -- yazýnýn içinde geçen her n harfi için merhaba yazdýrdýk


--select  lower(replace('Hasancan Güzel',' ','')) + '@benimfirmam.com'  -- + birleþtirme için kullandýk

--select adSoyad,replace(lower(adSoyad),' ','')+'@firma.com' as'mail adresi' from Doktorlar

--Sercan Furkan adýnda, Amasyada yaþayan bölümü 3 olan doktoru kaydedecek sorguyu yazýnýz
--insert into Doktorlar values('Sercan Furkan','Amasya',3)
--select * from Doktorlar


--------Güncelleme---------
--Update Doktorlar set adSoyad='Sercan Ahmet Furkan' where id=12  --where koþulunu girmezsek tüm tablodaki adsoyadý güncller
--select * from Doktorlar


--use KutuphaneDb
--update Kitaplar set sayfaSayisi=sayfaSayisi*1.2
--select *from Kitaplar

-------------SÝLME------------
--use HastaneDb
--Delete from Doktorlar where id=6
--select * from Doktorlar

--delete from Doktorlar where bolumId IS NULL  -- nul deðer sileceksek IS yazmamýz lazým =iþe yaramaz
--SELECT*FROM Doktorlar











