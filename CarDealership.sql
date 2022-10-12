CREATE TABLE CarManufacturer(
		id INT,
		manufacturer VARCHAR(20),
		country VARCHAR(30),
		CONSTRAINT carManufacturerIdPk PRIMARY KEY(id)
);

CREATE TABLE CarModel(
	id INT,
	manufacturerId INT,
	model VARCHAR(20),
	engine VARCHAR(30),
	price INT,
	CONSTRAINT carModelIdPk PRIMARY KEY(id),
	CONSTRAINT modelManufacturerIdFk FOREIGN KEY(manufacturerId) REFERENCES CarManufacturer(id)
);

drop table CarModel;
drop table CarManufacturer;
INSERT INTO CarManufacturer VALUES
(1, 'Alfa Romeo', 'Italy'),
(2, 'Aston Martin', 'United Kingdom'),
(3, 'Audi', 'Germany'),
(4, 'BMW', 'Germany'),
(5, 'Chevrolet', 'United States of America'),
(6, 'Dodge', 'United States of America'),
(7, 'Ferrari', 'Italy'),
(8, 'Honda', 'Japan'),
(9, 'McLaren', 'United States of America'),
(10, 'Porsche', 'Germany'),
(11, 'Nissan', 'Japan'),
(12, 'Peugeot', 'France'),
(13, 'Renault', 'France'),
(14, 'Rolls-Royce', 'United Kingdom'),
(15, 'Rimac Automobili', 'Croatia'),
(16, 'Suzuki', 'Japan'),
(17, 'Tesla', 'United States of America'),
(18, 'Toyota', 'Japan'),
(19, 'Volkswagen', 'Germany'),
(20, 'Yugo', 'Serbia');

INSERT INTO CarModel VALUES
(1,(SELECT id FROM CarManufacturer WHERE manufacturer='Alfa Romeo'),'Giulia','2.0L 8AT',25000),
(2,(SELECT id FROM CarManufacturer WHERE manufacturer='Alfa Romeo'),'Tonale','1.5L 7AT',35000),
(3,(SELECT id FROM CarManufacturer WHERE manufacturer='Audi'),'A8','55 TFSI QUATTRO',25000),
(4,(SELECT id FROM CarManufacturer WHERE manufacturer='BMW'),'X7','40D XDRIVE 8AT AWD',100000),
(5,(SELECT id FROM CarManufacturer WHERE manufacturer='BMW'),'i4','EDRIVE 40',64000),
(6,(SELECT id FROM CarManufacturer WHERE manufacturer='Honda'),'Civic','1.5L 16V VTEC 6MT',92100),
(7,(SELECT id FROM CarManufacturer WHERE manufacturer='Honda'),'Accord','1.5L CVT',82000),
(8,(SELECT id FROM CarManufacturer WHERE manufacturer='McLaren'),'Artura','3.0L V6 8AT',215000),
(9,(SELECT id FROM CarManufacturer WHERE manufacturer='Porsche'),'Panamera Turbo S','4.0L V8 8AT',333000),
(10,(SELECT id FROM CarManufacturer WHERE manufacturer='Nissan'),'Skyline GT-R','2.6 TT 6MT',221000),
(11,(SELECT id FROM CarManufacturer WHERE manufacturer='Nissan'),'Qashqai','1.5L E-POWER',5423200),
(12,(SELECT id FROM CarManufacturer WHERE manufacturer='Peugeot'),'408','PureTech 130 EAT8',120000),
(13,(SELECT id FROM CarManufacturer WHERE manufacturer='Peugeot'),'208','1.2L PureTech 100 8AT',200000),
(14,(SELECT id FROM CarManufacturer WHERE manufacturer='Renault'),'Megane','1.3L TCE 6MT',22000),
(15,(SELECT id FROM CarManufacturer WHERE manufacturer='Rimac Automobili'),'Nevera','120 KWH',1000000),
(16,(SELECT id FROM CarManufacturer WHERE manufacturer='Aston Martin'),'Valhalla','4.0L V8 8AT',120000),
(17,(SELECT id FROM CarManufacturer WHERE manufacturer='Chevrolet'),'Blazer','2.0L 9AT',46000),
(18,(SELECT id FROM CarManufacturer WHERE manufacturer='Dodge'),'Challanger','3.6 V6 8AT',23500),
(19,(SELECT id FROM CarManufacturer WHERE manufacturer='Ferrari'),'Roma','4.0L V8 8AT',27000),
(20,(SELECT id FROM CarManufacturer WHERE manufacturer='Rolls-Royce'),'Ghost','6.75L V12 8AT AWD',89000),
(21,(SELECT id FROM CarManufacturer WHERE manufacturer='Suzuki'),'Ignis','1.2L CVT',10000),
(22,(SELECT id FROM CarManufacturer WHERE manufacturer='Tesla'),'Model S','100D',100000),
(23,(SELECT id FROM CarManufacturer WHERE manufacturer='Tesla'),'Model Y','Y Standard Range 60',60000),
(24,(SELECT id FROM CarManufacturer WHERE manufacturer='Toyota'),'GR 86','2.4L DOHC 6AT',21000),
(25,(SELECT id FROM CarManufacturer WHERE manufacturer='Volkswagen'),'Golf R','2.0L 4Motion 6MT AWD',12000),
(26,(SELECT id FROM CarManufacturer WHERE manufacturer='Volkswagen'),'Tiguan','2.0L TSI 4Motion 8AT',11111),
(27,(SELECT id FROM CarManufacturer WHERE manufacturer='Volkswagen'),'Passat','1.5L TSI 6MT',20000),
(28,(SELECT id FROM CarManufacturer WHERE manufacturer='Volkswagen'),'Arteon','2.0L TSI 4Motion 8AT',25000),
(29,(SELECT id FROM CarManufacturer WHERE manufacturer='Yugo'),'45A','0.9L OHV I4',500);

select * from CarModel;

select * from CarManufacturer;
select * from CarModel ORDER BY price DESC;

select * from CarModel ORDER BY id ASC OFFSET 0 ROWS FETCH NEXT 4 ROWS ONLY;

ALTER TABLE CarModel ADD dateOfManufacturing DATE;
ALTER TABLE CarModel ADD bodyType VARCHAR(15);
UPDATE CarModel SET bodyType='Sedan' WHERE id=1;
UPDATE CarModel SET bodyType='Sedan' WHERE id=2;
UPDATE CarModel SET bodyType='Hatchback' WHERE id=3;
UPDATE CarModel SET bodyType='SUV' WHERE id=4;
UPDATE CarModel SET bodyType='Hatchback' WHERE id=5;
UPDATE CarModel SET bodyType='Sedan' WHERE id=6;
UPDATE CarModel SET bodyType='Sedan' WHERE id=7;
UPDATE CarModel SET bodyType='Caravan' WHERE id=8;
UPDATE CarModel SET bodyType='Sedan' WHERE id=9;
UPDATE CarModel SET bodyType='SUV' WHERE id=10;
UPDATE CarModel SET bodyType='SUV' WHERE id=11;
UPDATE CarModel SET bodyType='Hatchback' WHERE id=12;
UPDATE CarModel SET bodyType='Sedan' WHERE id=13;
UPDATE CarModel SET bodyType='Sedan' WHERE id=14;
UPDATE CarModel SET bodyType='Sedan' WHERE id=15;
UPDATE CarModel SET bodyType='SUV' WHERE id=16;
UPDATE CarModel SET bodyType='Caravan' WHERE id=17;
UPDATE CarModel SET bodyType='Caravan' WHERE id=18;
UPDATE CarModel SET bodyType='Hatchback' WHERE id=19;
UPDATE CarModel SET bodyType='SUV' WHERE id=20;
UPDATE CarModel SET bodyType='Sedan' WHERE id=21;
UPDATE CarModel SET bodyType='Sedan' WHERE id=22;
UPDATE CarModel SET bodyType='Hatchback' WHERE id=23;
UPDATE CarModel SET bodyType='Sedan' WHERE id=24;
UPDATE CarModel SET bodyType='Sedan' WHERE id=25;
UPDATE CarModel SET bodyType='SUV' WHERE id=26;
UPDATE CarModel SET bodyType='Sedan' WHERE id=27;
UPDATE CarModel SET bodyType='SUV' WHERE id=28;
UPDATE CarModel SET bodyType='Hatchback' WHERE id=29;

SELECT COUNT(manufacturerId) AS NumberOfCars, bodyType AS BodyType FROM CarModel GROUP BY bodyType ORDER BY COUNT(manufacturerId) DESC;
SELECT CarManufacturer.manufacturer, COUNT(CarModel.id)AS NumberOfModels  FROM CarManufacturer,CarModel WHERE CarManufacturer.id=CarModel.manufacturerId GROUP BY CarManufacturer.manufacturer ORDER BY NumberOfModels DESC;
CREATE INDEX idxManufacturer ON CarManufacturer(manufacturer);