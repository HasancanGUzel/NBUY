--sayf sayýsý 300 den büyük eþit olan kitaplarý listele
--use KutuphaneDb
--select * from Kitaplar where sayfaSayisi>=300

--stok adedi 90 ile 113 arasýndaki

--select * from Kitaplar where stok>=90 and stok<=113
--select * from Kitaplar where stok between 90 and 113


--sayfa sayýsý en çok olandan en az olana doðru sýrala
--select * from  Kitaplar order by sayfaSayisi DESC	

--TÜRE GÖRE KÜÇÜKTEN BÜYÜÐE SIRALA

--select  *  from Kitaplar order by  turId, sayfaSayisi DESC


