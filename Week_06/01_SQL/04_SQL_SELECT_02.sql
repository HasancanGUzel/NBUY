--sayf say�s� 300 den b�y�k e�it olan kitaplar� listele
--use KutuphaneDb
--select * from Kitaplar where sayfaSayisi>=300

--stok adedi 90 ile 113 aras�ndaki

--select * from Kitaplar where stok>=90 and stok<=113
--select * from Kitaplar where stok between 90 and 113


--sayfa say�s� en �ok olandan en az olana do�ru s�rala
--select * from  Kitaplar order by sayfaSayisi DESC	

--T�RE G�RE K���KTEN B�Y��E SIRALA

--select  *  from Kitaplar order by  turId, sayfaSayisi DESC


