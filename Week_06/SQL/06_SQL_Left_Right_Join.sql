use Northwind


--select C.CompanyName from Customers C INNER JOIN Orders O  --inner jo�n e�le�enleri getiriyor
--ON C.CustomerID = O.CustomerID

--select C.CompanyName from Customers C LEFT JOIN Orders O  --- left jo�n soldaki tabloyu getircek  sa�daki tabloyuda e�le�enleri getircek
--ON C.CustomerID = O.CustomerID
--WHERE O.OrderID IS NULL

--select C.CompanyName from Orders O RIGHT JOIN Customers C   --- right jo�n sa�daki tabloyu getircek  soldaki tabloyuda e�le�enleri getircek
--ON C.CustomerID = O.CustomerID
--WHERE O.OrderID IS NULL


--Hen�z hi� sat�lmam�� �r�nler
--select P.ProductName, OD.ProductID from Products P  LEFT JOIN   [Order Details] OD
--ON P.ProductID = OD.ProductID
--WHERE OD.ProductID IS NULL


--Hen�z sat�� yapamam�� �al��anlar� listeleyin
select * from Employees E  LEFT JOIN Orders O
ON E.EmployeeID = O.EmployeeID
WHERE O.EmployeeID IS NULL



