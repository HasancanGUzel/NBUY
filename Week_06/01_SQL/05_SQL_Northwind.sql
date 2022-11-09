--products tablosunu unitprice kolonuna g�re b�y�kten k����e s�rala
--use Northwind
--select * from Products order by UnitPrice desc

--unitprice i 100 ve �zerinde olanlar� g�sterizniz
--use Northwind
--select * from Products WHERE UnitPrice>100

--kategorisi 7 ve 8 olan �r�nleri listeleyiniz
--select * from Products where CategoryID=7 or CategoryID=8

--kategorisi 7 ve 8 olanlardan stok miktar�(unitstock)<=10 olan �r�nleri listeleyiniz.
--select * from Products where (CategoryID=7 or CategoryID=8)and UnitsInStock<=10


--kategorisi 7 ve 8 olanlardan stok miktar�(unitstock)<=10 olan �r�nlerin say�s�.
--select count(*) from Products where (CategoryID=7 or CategoryID=8)and UnitsInStock<=10


------------inner Join------------
--select *from Products INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID
--select Products.ProductName,Categories.CategoryName from Products INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID


-- k�sa yaz�lm�� hali
--select P.ProductName,C.CategoryName 
--	from Products P INNER JOIN Categories C
--	ON P.CategoryID=C.CategoryID

--select P.ProductName,C.CategoryName, P.UnitPrice
--	from Products P INNER JOIN Categories C
--	ON P.CategoryID=C.CategoryID
--	where CategoryName='Beverages' and P.UnitPrice<=40
--	order by P.UnitPrice desc


-----product name ve suppiler company name i g�steren bir sorgu yaz�n�z

--select P.ProductName,S.CompanyName
--	from Products P INNER JOIN Suppliers S
--	ON P.SupplierID=S.SupplierID

---ALMANYADAN TEDAR�K ED�LEN ��RNLER�N PRODUCT NAME L�STES�

--select P.ProductName
--	from Products P INNER JOIN Suppliers S
--	ON P.SupplierID=S.SupplierID
--	where Country='Germany' 

---ALMANYADAN TEDAR�K ED�LEN ��RNLER�N   toplam tutar�
--select SUM(P.UnitPrice*P.UnitsInStock) AS'toplam tutar'
--	from Products P INNER JOIN Suppliers S
--	ON P.SupplierID=S.SupplierID
--	where Country='germany' 

---chai sat��lar�n�n topla tutar�
--select SUM(OD.UnitPrice*OD.Quantity)
--	from Products P INNER JOIN[Order Details] OD   --- order details aras� bo�luk oldu�u i�in parantez i�inde yazmam�z laz�m
--	ON P.ProductID=OD.ProductID
--	where P.ProductName='Chai'

---Germany yap�lan chai sat��lar�n�n topla tutar�

--select SUM(OD.UnitPrice*OD.Quantity)
--	from Orders O INNER JOIN[Order Details] OD   
--	ON O.OrderID=OD.OrderID INNER JOIN Products P
--	ON OD.ProductID=P.ProductID
--	where P.ProductName='Chai' and O.ShipCountry='Germany'



---ernst handel m��terisine yap�lan sat�� tutar�n�n toplam�
select SUM(UnitPrice*Quantity)
	from [Order Details] OD INNER JOIN Orders O
	ON OD.OrderID=O.OrderID INNER JOIN  Customers C
	ON O.CustomerID=C.CustomerID
	where C.CompanyName='Ernst Handel'


