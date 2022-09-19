CREATE DATABASE Cars;
GO

USE Cars
GO

CREATE TABLE Car (
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Make NVARCHAR(100) NOT NULL,
	Model NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE CarTime (
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	CarId INT NOT NULL FOREIGN KEY REFERENCES Car(Id),
	[Year] INT NOT NULL,
	[Trim] NVARCHAR(200) NOT NULL,
	DriveType NVARCHAR(3) NOT NULL,
	Transmission NVARCHAR(2) NOT NULL,
	ZeroToSixtyTime DECIMAL(4,1) NOT NULL,
	QuarterMileTime DECIMAL(4,1) NOT NULL,
	QuarterMileSpeed DECIMAL(4,1) NOT NULL,
);
GO

INSERT INTO Car
	(Make, Model)
VALUES 
	('BMW', 'M2'),
	('BMW', 'M3'),
	('Porsche', '911');

INSERT INTO CarTime
	(CarId, [Year], [TRIM], DriveType, Transmission, ZeroToSixtyTime, QuarterMileTime, QuarterMileSpeed )
VALUES 
	((SELECT Id FROM Car WHERE Make = 'BMW' AND Model='M2' ), 2020, 'CS Coupe', 'RWD', '7A', 3.4, 11.7, 120),
	((SELECT Id FROM Car WHERE Make = 'BMW' AND Model='M2' ), 2020, 'CS Coupe', 'RWD', '6M', 4.1, 12.4, 117.6),
	((SELECT Id FROM Car WHERE Make = 'BMW' AND Model='M2' ), 2019, 'Competition Coupe', 'RWD', '6M', 3.9, 12.4, 114),

	((SELECT Id FROM Car WHERE Make = 'BMW' AND Model='M3' ), 2022, 'Competition xDrive Sedan', 'AWD', '8A', 3.0, 11.1, 124.7),
	((SELECT Id FROM Car WHERE Make = 'BMW' AND Model='M3' ), 2022, 'Sedan', 'RWD', '6M', 3.4, 11.6, 121),
	((SELECT Id FROM Car WHERE Make = 'BMW' AND Model='M3' ), 2021, 'Competition Sedan', 'RWD', '8A', 3.5, 11.6, 124),

	((SELECT Id FROM Car WHERE Make = 'Porsche' AND Model='911' ), 2022, 'Carrera 4 GTS Coupe', 'AWD', '8A', 2.8, 10.9, 126.7),
	((SELECT Id FROM Car WHERE Make = 'Porsche' AND Model='911' ), 2022, 'GT3 Coupe', 'RWD', '6M', 3.3, 11.5, 124)
