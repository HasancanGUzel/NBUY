use Northwind


--select C.CompanyName from Customers C INNER JOIN Orders O  --inner joýn eþleþenleri getiriyor
--ON C.CustomerID = O.CustomerID

--select C.CompanyName from Customers C LEFT JOIN Orders O  --- left joýn soldaki tabloyu getircek  saðdaki tabloyuda eþleþenleri getircek
--ON C.CustomerID = O.CustomerID
--WHERE O.OrderID IS NULL

--select C.CompanyName from Orders O RIGHT JOIN Customers C   --- right joýn saðdaki tabloyu getircek  soldaki tabloyuda eþleþenleri getircek
--ON C.CustomerID = O.CustomerID
--WHERE O.OrderID IS NULL


--Henüz hiç satýlmamýþ ürünler
--select P.ProductName, OD.ProductID from Products P  LEFT JOIN   [Order Details] OD
--ON P.ProductID = OD.ProductID
--WHERE OD.ProductID IS NULL


--Henüz satýþ yapamamýþ çalýþanlarý listeleyin
select * from Employees E  LEFT JOIN Orders O
ON E.EmployeeID = O.EmployeeID
WHERE O.EmployeeID IS NULL



