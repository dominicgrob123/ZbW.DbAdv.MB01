use Northwind;


SET STATISTICS IO ON;
GO
SET STATISTICS TIME ON;
GO

SELECT	CustomerID				= c.CustomerID,
		OrderID					= o.OrderID,
		RowN					= ROW_NUMBER() OVER (PARTITION BY c.CustomerID ORDER BY o.OrderDate DESC)
FROM	dbo.Customers			AS c
		INNER JOIN
		dbo.Orders				AS o
			ON	o.CustomerID	= c.CustomerID;

SET STATISTICS IO OFF;
GO
SET STATISTICS TIME OFF;
GO

USE PL_SampleData
SELECT *,
	AVG(ClosePrice)
		OVER(PARTITION BY TickerSymbol
			ORDER BY TradeDate
			RANGE BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)
FROM dbo.StockHistory
ORDER BY TickerSymbol;

------ ohne window function


SELECT TickerSymbol, TradeDate, ClosePrice AS c, ClosePrice - c AS Difference

FROM dbo.StockHistory
ORDER BY TickerSymbol

SELECT *, 
	ClosePrice - LAG(ClosePrice) OVER ( PARTItion by TickerSymbol Order BY TradeDate)
FROM dbo.StockHistory;

SELECT
    s.TickerSymbol,
    s.TradeDate,
    s.ClosePrice,
    s.ClosePrice - p.ClosePrice AS Dif
FROM StockHistory s
LEFT JOIN StockHistory p
    ON p.TickerSymbol = s.TickerSymbol
   AND p.TradeDate = (
        SELECT MAX(sh.TradeDate)
        FROM StockHistory sh
        WHERE sh.TickerSymbol = s.TickerSymbol
          AND sh.TradeDate < s.TradeDate
   )
ORDER BY s.TickerSymbol, s.TradeDate;



USE AdventureWorks2022;
GO
--What are the first four orders for each product?
SELECT	SOD.ProductID, 
		SOH.SalesOrderID,
		FORMAT(SOH.OrderDate,'yyyy-MM-dd') AS OrderDate
FROM Sales.SalesOrderHeader AS SOH
	JOIN Sales.SalesOrderDetail AS SOD
		ON SOH.SalesOrderID = SOD.SalesOrderID
WHERE SOH.OrderDate >= '2011-01-01'
	AND SOH.OrderDate < '2012-01-01';

USE AdventureWorks2022;
GO

WITH FirstFourPerProduct AS
(
    SELECT
        SOD.ProductID,
        SOH.SalesOrderID,
        FORMAT(SOH.OrderDate,'yyyy-MM-dd') AS OrderDate,
        ROW_NUMBER() OVER (
            PARTITION BY SOD.ProductID
            ORDER BY SOH.OrderDate, SOH.SalesOrderID
        ) AS rn
    FROM Sales.SalesOrderHeader AS SOH
    JOIN Sales.SalesOrderDetail AS SOD
        ON SOH.SalesOrderID = SOD.SalesOrderID
    WHERE SOH.OrderDate >= '2011-01-01'
      AND SOH.OrderDate <  '2012-01-01'
)
SELECT
    ProductID,
    SalesOrderID,
    OrderDate
FROM FirstFourPerProduct
WHERE rn <= 4
ORDER BY ProductID, OrderDate, SalesOrderID;
