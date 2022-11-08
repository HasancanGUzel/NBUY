
--Select distinct CategoryId from Products   ---distinct tekrarlý verileri göstermez

--1)Bugüne kadar hangi ülkelere kargo gönderilmiþ
--Select distinct ShipCountry from Orders 
--Order by ShipCountry

--2)Hnagi ülkeye ne kadar satýþ yapmýþýz
--Select  O.ShipCountry, SUM(OD.Quantity * OD.UnitPrice) AS 'TOPLAM TUTAR' from Orders O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID
--Group by O.ShipCountry  --select yaptýðýmýz kolona göre group by yapmamýz lazým burdaki farklý select deki farklý olamaz
--order by 'Toplam tutar' desc

--3) En çok satýþ yapýlan üç ülke
--Select  TOP (3) O.ShipCountry, SUM(OD.Quantity * OD.UnitPrice) AS 'TOPLAM TUTAR' from Orders O INNER JOIN [Order Details] OD
--ON O.OrderID = OD.OrderID
--Group by O.ShipCountry  --select yaptýðýmýz kolona göre group by yapmamýz lazým burdaki farklý select deki farklý olamaz
--order by 'Toplam tutar' desc

--4) Elimizde en çok stoðu bulunan ilk 3 ürün
--Select  TOP (3) ProductName, UnitsInStock from Products
--Order  by UnitsInStock desc

--5)Hangi kategoride kaç adet ürünümüz var
--Select C.CategoryName, COUNT(*) AS'ADET' from Categories C INNER JOIN Products P
--ON C.CategoryID = P.CategoryID
--group by C.CategoryName
--Having Count(*)>10   --gruplanmýþ olan dataya filtre uygulandý
--order by adet desc



--6)hangi üründen kaç tane satýlmýþtýr

--select P.ProductName,COUNT(*) AS 'adet'from Products P INNER JOIN [Order Details] OD
--on P.ProductID = OD.ProductID
--Group by P.ProductName
--ORDER BY ADET DESC



--7)En çok kazandýran ilk 3 ürün hangisidir
--select	top(3) P.ProductName,SUM(OD.Quantity * OD.UnitPrice) AS 'toplam' from  Products P INNER JOIN	 [Order Details] OD
--ON P.ProductID = OD.ProductID
--group by P.ProductName
--order by toplam desc


--8)Hnagi kargo þirketine ne kadar ödeme yapýlmýþtýr(Freight)
--select  S.CompanyName,SUM(O.Freight) as'toplam' from  Shippers S INNER JOIN Orders O
--On S.ShipperID = O.ShipVia
--Group by S.CompanyName
--order by toplam desc

--9) En az ödeme yapýlmýþ kargo þirketi
--select top(1) S.CompanyName,SUM(O.Freight) as'toplam' from  Shippers S INNER JOIN Orders O
--On S.ShipperID = O.ShipVia
--Group by S.CompanyName
--order by toplam asc


--10)HANGÝ MÜÞTERÝNE NE KADAR TUTARDA SATIÞ YAPILMIÞTIR

--SELECT C.CompanyName,SUM(OD.Quantity*OD.UnitPrice) as'toplam'
--	FROM Customers C INNER JOIN Orders O
--	ON C.CustomerID = O.CustomerID INNER JOIN [Order Details] OD
--	ON O.OrderID = OD.OrderID
--	GROUP BY C.CompanyName
--	ORDER BY toplam DESC 
	
--11)bölgelere göre satýþ tutarlarý
--SELECT R.RegionDescription ,SUM(OD.Quantity*OD.UnitPrice) AS 'TOPLAM'
--	from Region R INNER JOIN Territories T
--	ON R.RegionId = T.RegionID INNER JOIN EmployeeTerritories ET
--	ON T.TerritoryID = ET.TerritoryID INNER JOIN Employees E
--	ON ET .EmployeeID =E.EmployeeID  INNER JOIN  Orders O
--	ON E.EmployeeID = O.EmployeeID INNER JOIN [Order Details] OD
--	ON O.OrderID = OD.OrderID
--	GROUP BY R.RegionDescription
--	order by toplam desc




--12) Hangi bölgede hangi üründen  kaç paralýk satýþ yapýlmýþtýr

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

--13) Hangi bölgede hangi üründen  kaç adet satýþ yapýlmýþtýr

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





