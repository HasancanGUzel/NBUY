
--Select distinct CategoryId from Products   ---distinct tekrarl� verileri g�stermez

--1)Bug�ne kadar hangi �lkelere kargo g�nderilmi�
--Select distinct ShipCountry from Orders 
--Order by ShipCountry

--2)Hnagi �lkeye ne kadar sat�� yapm���z
--Select  O.ShipCountry, SUM(OD.Quantity * OD.UnitPrice) AS 'TOPLAM TUTAR' from Orders O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID
--Group by O.ShipCountry  --select yapt���m�z kolona g�re group by yapmam�z laz�m burdaki farkl� select deki farkl� olamaz
--order by 'Toplam tutar' desc

--3) En �ok sat�� yap�lan �� �lke
--Select  TOP (3) O.ShipCountry, SUM(OD.Quantity * OD.UnitPrice) AS 'TOPLAM TUTAR' from Orders O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID
--Group by O.ShipCountry  --select yapt���m�z kolona g�re group by yapmam�z laz�m burdaki farkl� select deki farkl� olamaz
--order by 'Toplam tutar' desc

--4) Elimizde en �ok sto�u bulunan ilk 3 �r�n
--Select  TOP (3) ProductName, UnitsInStock from Products
--Order  by UnitsInStock desc

--5)Hangi kategoride ka� adet �r�n�m�z var
--Select C.CategoryName, COUNT(*) AS'ADET' from Categories C INNER JOIN Products P
--ON C.CategoryID = P.CategoryID
--group by C.CategoryName
--Having Count(*)>10   --gruplanm�� olan dataya filtre uyguland�
--order by adet desc



--6)hangi �r�nden ka� tane sat�lm��t�r

--select P.ProductName,COUNT(*) AS 'adet'from Products P INNER JOIN [Order Details] OD
--on P.ProductID = OD.ProductID
--Group by P.ProductName
--ORDER BY ADET DESC



--7)En �ok kazand�ran ilk 3 �r�n hangisidir
--select	top(3) P.ProductName,SUM(OD.Quantity * OD.UnitPrice) AS 'toplam' from  Products P INNER JOIN	 [Order Details] OD
--ON P.ProductID = OD.ProductID
--group by P.ProductName
--order by toplam desc


--8)Hnagi kargo �irketine ne kadar �deme yap�lm��t�r(Freight)
--select  S.CompanyName,SUM(O.Freight) as'toplam' from  Shippers S INNER JOIN Orders O
--On S.ShipperID = O.ShipVia
--Group by S.CompanyName
--order by toplam desc

--9) En az �deme yap�lm�� kargo �irketi
--select top(1) S.CompanyName,SUM(O.Freight) as'toplam' from  Shippers S INNER JOIN Orders O
--On S.ShipperID = O.ShipVia
--Group by S.CompanyName
--order by toplam asc


--10)HANG� M��TER�NE NE KADAR TUTARDA SATI� YAPILMI�TIR

--SELECT C.CompanyName,SUM(OD.Quantity*OD.UnitPrice) as'toplam'
--	FROM Customers C INNER JOIN Orders O
--	ON C.CustomerID = O.CustomerID INNER JOIN [Order Details] OD
--	ON O.OrderID = OD.OrderID
--	GROUP BY C.CompanyName
--	ORDER BY toplam DESC 
	
--11)b�lgelere g�re sat�� tutarlar�
--SELECT R.RegionDescription ,SUM(OD.Quantity*OD.UnitPrice) AS 'TOPLAM'
--	from Region R INNER JOIN Territories T
--	ON R.RegionId = T.RegionID INNER JOIN EmployeeTerritories ET
--	ON T.TerritoryID = ET.TerritoryID INNER JOIN Employees E
--	ON ET .EmployeeID =E.EmployeeID  INNER JOIN  Orders O
--	ON E.EmployeeID = O.EmployeeID INNER JOIN [Order Details] OD
--	ON O.OrderID = OD.OrderID
--	GROUP BY R.RegionDescription
--	order by toplam desc




--12) Hangi b�lgede hangi �r�nden  ka� paral�k sat�� yap�lm��t�r

--SELECT R.RegionDescription,P.ProductName, SUM(OD.Quantity*OD.UnitPrice) AS 'TOPLAM'
--	from Region R INNER JOIN Territories T
--	ON R.RegionId = T.RegionID INNER JOIN EmployeeTerritories ET
--	ON T.TerritoryID = ET.TerritoryID INNER JOIN Employees E
--	ON ET .EmployeeID =E.EmployeeID INNER JOIN  Orders O
--	ON E.EmployeeID = O.EmployeeID INNER JOIN [Order Details] OD
--	ON O.OrderID = OD.OrderID INNER JOIN Products P
--	ON OD.ProductID = P.ProductID
--	GROUP BY R.RegionDescription,P.ProductName
--	order by R.RegionDescription,P.ProductName,TOPLAM desc

--13) Hangi b�lgede hangi �r�nden  ka� adet sat�� yap�lm��t�r

--SELECT R.RegionDescription,P.ProductName, Count(*) AS 'TOPLAM'
--	from Region R INNER JOIN Territories T
--	ON R.RegionId = T.RegionID INNER JOIN EmployeeTerritories ET
--	ON T.TerritoryID = ET.TerritoryID INNER JOIN Employees E
--	ON ET .EmployeeID =E.EmployeeID INNER JOIN  Orders O
--	ON E.EmployeeID = O.EmployeeID INNER JOIN [Order Details] OD
--	ON O.OrderID = OD.OrderID INNER JOIN Products P
--	ON OD.ProductID = P.ProductID
--	GROUP BY R.RegionDescription,P.ProductName
--	order by R.RegionDescription,P.ProductName,TOPLAM desc





