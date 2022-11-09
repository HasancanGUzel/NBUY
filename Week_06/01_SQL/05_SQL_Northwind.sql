--products tablosunu unitprice kolonuna göre büyükten küçüðe sýrala
--use Northwind
--select * from Products order by UnitPrice desc

--unitprice i 100 ve üzerinde olanlarý gösterizniz
--use Northwind
--select * from Products WHERE UnitPrice>100

--kategorisi 7 ve 8 olan ürünleri listeleyiniz
--select * from Products where CategoryID=7 or CategoryID=8

--kategorisi 7 ve 8 olanlardan stok miktarý(unitstock)<=10 olan ürünleri listeleyiniz.
--select * from Products where (CategoryID=7 or CategoryID=8)and UnitsInStock<=10


--kategorisi 7 ve 8 olanlardan stok miktarý(unitstock)<=10 olan ürünlerin sayýsý.
--select count(*) from Products where (CategoryID=7 or CategoryID=8)and UnitsInStock<=10


------------inner Join------------
--select *from Products INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID
--select Products.ProductName,Categories.CategoryName from Products INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID


-- kýsa yazýlmýþ hali
--select P.ProductName,C.CategoryName 
--	from Products P INNER JOIN Categories C
--	ON P.CategoryID=C.CategoryID

--select P.ProductName,C.CategoryName, P.UnitPrice
--	from Products P INNER JOIN Categories C
--	ON P.CategoryID=C.CategoryID
--	where CategoryName='Beverages' and P.UnitPrice<=40
--	order by P.UnitPrice desc


-----product name ve suppiler company name i gösteren bir sorgu yazýnýz

--select P.ProductName,S.CompanyName
--	from Products P INNER JOIN Suppliers S
--	ON P.SupplierID=S.SupplierID

---ALMANYADAN TEDARÝK EDÝLEN ÜÜRNLERÝN PRODUCT NAME LÝSTESÝ

--select P.ProductName
--	from Products P INNER JOIN Suppliers S
--	ON P.SupplierID=S.SupplierID
--	where Country='Germany' 

---ALMANYADAN TEDARÝK EDÝLEN ÜÜRNLERÝN   toplam tutarý
--select SUM(P.UnitPrice*P.UnitsInStock) AS'toplam tutar'
--	from Products P INNER JOIN Suppliers S
--	ON P.SupplierID=S.SupplierID
--	where Country='germany' 

---chai satýþlarýnýn topla tutarý
--select SUM(OD.UnitPrice*OD.Quantity)
--	from Products P INNER JOIN[Order Details] OD   --- order details arasý boþluk olduðu için parantez içinde yazmamýz lazým
--	ON P.ProductID=OD.ProductID
--	where P.ProductName='Chai'

---Germany yapýlan chai satýþlarýnýn topla tutarý

--select SUM(OD.UnitPrice*OD.Quantity)
--	from Orders O INNER JOIN[Order Details] OD   
--	ON O.OrderID=OD.OrderID INNER JOIN Products P
--	ON OD.ProductID=P.ProductID
--	where P.ProductName='Chai' and O.ShipCountry='Germany'



---ernst handel müþterisine yapýlan satýþ tutarýnýn toplamý
select SUM(UnitPrice*Quantity)
	from [Order Details] OD INNER JOIN Orders O
	ON OD.OrderID=O.OrderID INNER JOIN  Customers C
	ON O.CustomerID=C.CustomerID
	where C.CompanyName='Ernst Handel'


