SELECT * FROM Customers 
	WHERE ContactName LIKE 'B%'

INSERT INTO Products ( ProductName, UnitPrice)
	VALUES ( 'New Awsome Tea', '15')

SELECT Orders.OrderID, Orders.ShipName, Orders.ShipAddress, Orders.ShipCity, 
		[Order Details].UnitPrice, [Order Details].Quantity, [Order Details].Discount 
	FROM Orders INNER JOIN [Order Details] 
	ON  ([Order Details].OrderID = Orders.OrderID) 
	ORDER BY UnitPrice ASC

SELECT * FROM Products