USE CoffeeShop;

GO

CREATE PROC uspAddSupplier
	@id varchar(20),
	@name nvarchar(100),
	@address nvarchar(200)
AS 
	BEGIN
		INSERT INTO Supplier VALUES(@id, @name, @address);
	END;
