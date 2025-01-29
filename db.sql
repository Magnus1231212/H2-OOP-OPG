-- Use the database
USE `SommerhusDB`;

-- Disable foreign key checks to avoid conflicts during truncation
SET FOREIGN_KEY_CHECKS = 0;

-- Clear all data from the tables
TRUNCATE TABLE `SommerhusSaesonPris`;
TRUNCATE TABLE `Reservation`;
TRUNCATE TABLE `Saesonkategori`;
TRUNCATE TABLE `Lejlighedskompleks`;
TRUNCATE TABLE `Sommerhus`;
TRUNCATE TABLE `Kunde`;
TRUNCATE TABLE `Omraade`;
TRUNCATE TABLE `Konsulent`;
TRUNCATE TABLE `Inspektoer`;
TRUNCATE TABLE `Ejer`;
TRUNCATE TABLE `User`;

CREATE TABLE IF NOT EXISTS `Ejer` (
  `EjerID` INT PRIMARY KEY AUTO_INCREMENT,
  `Navn` VARCHAR(100) NOT NULL,
  `Email` VARCHAR(255),
  `Tlf` VARCHAR(100),
  `Adresse` VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS `Sommerhus` (
  `HusID` INT PRIMARY KEY AUTO_INCREMENT,
  `EjerID` INT,
  `Lokation` VARCHAR(255),
  `Klassifikation` VARCHAR(255),
  `OmraadeID` INT,
  `StandardPris` DECIMAL(10,2)
);

CREATE TABLE IF NOT EXISTS `Reservation` (
  `ReservationID` INT PRIMARY KEY AUTO_INCREMENT,
  `HusID` INT,
  `KundeID` INT,
  `StartUge` INT NOT NULL,
  `AntalUger` INT NOT NULL,
  `TotalPris` DECIMAL(10,2)
);

CREATE TABLE IF NOT EXISTS `Kunde` (
  `KundeID` INT PRIMARY KEY AUTO_INCREMENT,
  `Navn` VARCHAR(100) NOT NULL,
  `Telefon` VARCHAR(20),
  `Email` VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS `Omraade` (
  `OmraadeID` INT PRIMARY KEY AUTO_INCREMENT,
  `Navn` VARCHAR(100),
  `KonsulentID` INT
);

CREATE TABLE IF NOT EXISTS `Konsulent` (
  `KonsulentID` INT PRIMARY KEY AUTO_INCREMENT,
  `Navn` VARCHAR(100),
  `KontaktInfo` VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS `Inspektoer` (
  `InspektoerID` INT PRIMARY KEY AUTO_INCREMENT,
  `Navn` VARCHAR(100),
  `KontaktInfo` VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS `Saesonkategori` (
  `KategoriID` INT PRIMARY KEY AUTO_INCREMENT,
  `Navn` VARCHAR(50),
  `Uger` VARCHAR(50),
  `Saeson` ENUM('super','hoej','medium','lav'),
  `PrisProcent` DECIMAL(3,2)
);

CREATE TABLE IF NOT EXISTS `Lejlighedskompleks` (
  `KompleksID` INT PRIMARY KEY AUTO_INCREMENT,
  `InspektoerID` INT,
  `Type` VARCHAR(50),
  `SommerhusID` INT
);

CREATE TABLE IF NOT EXISTS `SommerhusSaesonPris` (
  `StandardPris` DECIMAL(10,2),
  `SommerhusID` INT,
  `SaesonkategoriID` INT
);

CREATE TABLE IF NOT EXISTS `User` (
  `UserID` INT PRIMARY KEY AUTO_INCREMENT,
  `Brugernavn` VARCHAR(255) UNIQUE NOT NULL,
  `Adgangskode` VARCHAR(255) NOT NULL
);

-- Add foreign key constraints
ALTER TABLE `Sommerhus` ADD FOREIGN KEY (`EjerID`) REFERENCES `Ejer` (`EjerID`);

ALTER TABLE `Reservation` ADD FOREIGN KEY (`HusID`) REFERENCES `Sommerhus` (`HusID`);

ALTER TABLE `Sommerhus` ADD FOREIGN KEY (`OmraadeID`) REFERENCES `Omraade` (`OmraadeID`);

ALTER TABLE `Reservation` ADD FOREIGN KEY (`KundeID`) REFERENCES `Kunde` (`KundeID`);

ALTER TABLE `Omraade` ADD FOREIGN KEY (`KonsulentID`) REFERENCES `Konsulent` (`KonsulentID`);

ALTER TABLE `Lejlighedskompleks` ADD FOREIGN KEY (`InspektoerID`) REFERENCES `Inspektoer` (`InspektoerID`);

ALTER TABLE `Lejlighedskompleks` ADD FOREIGN KEY (`SommerhusID`) REFERENCES `Sommerhus` (`HusID`);

ALTER TABLE `SommerhusSaesonPris` ADD FOREIGN KEY (`SommerhusID`) REFERENCES `Sommerhus` (`HusID`);

ALTER TABLE `SommerhusSaesonPris` ADD FOREIGN KEY (`SaesonkategoriID`) REFERENCES `Saesonkategori` (`KategoriID`);

-- Insert data into `Ejer`
INSERT INTO `Ejer` (`EjerID`, `Navn`, `Email`, `Tlf`, `Adresse`) VALUES
(1, 'John Doe', 'johndoe@example.com', '12345678', '123 Main St'),
(2, 'Jane Smith', 'janesmith@example.com', '87654321', '456 Elm St'),
(3, 'Emily Brown', 'emilybrown@example.com', '45612378', '789 Oak St'),
(4, 'Mark Wilson', 'markwilson@example.com', '11223344', '101 Pine St'),
(5, 'Sophia Davis', 'sophiadavis@example.com', '99887766', '202 Cedar St');

-- Insert data into `Inspektoer`
INSERT INTO `Inspektoer` (`InspektoerID`, `Navn`, `KontaktInfo`) VALUES
(2, 'Anna White', 'anna.white@inspection.com'),
(3, 'Paul Green', 'paul.green@inspection.com'),
(4, 'Laura Brown', 'laura.brown@inspection.com');

-- Insert data into `Konsulent`
INSERT INTO `Konsulent` (`KonsulentID`, `Navn`, `KontaktInfo`) VALUES
(1, 'Michael Johnson', 'mjohnson@consulting.com'),
(2, 'Sarah Taylor', 'staylor@consulting.com'),
(3, 'Daniel Lewis', 'daniel.lewis@consulting.com'),
(4, 'Olivia Martin', 'olivia.martin@consulting.com');

-- Insert data into `Kunde`
INSERT INTO `Kunde` (`KundeID`, `Navn`, `Telefon`, `Email`) VALUES
(1, 'Alice Green', '99887766', 'alice.green@example.com'),
(2, 'Bob Black', '77665544', 'bob.black@example.com'),
(3, 'Charlie Blue', '66554433', 'charlie.blue@example.com'),
(4, 'David White', '55443322', 'david.white@example.com'),
(5, 'Emma Harris', '44332211', 'emma.harris@example.com');

-- Insert data into `Lejlighedskompleks`
INSERT INTO `Lejlighedskompleks` (`KompleksID`, `InspektoerID`, `Type`, `SommerhusID`) VALUES
(1, 1, 'Apartment', NULL),
(2, 2, 'Villa', NULL),
(3, 3, 'Townhouse', NULL),
(4, 4, 'Cottage', NULL);

-- Insert data into `Omraade`
INSERT INTO `Omraade` (`OmraadeID`, `Navn`, `KonsulentID`) VALUES
(1, 'North Region', 1),
(2, 'South Region', 2),
(3, 'East Region', 3),
(4, 'West Region', 4);

-- Insert data into `Reservation`
INSERT INTO `Reservation` (`ReservationID`, `HusID`, `KundeID`, `StartUge`, `AntalUger`, `TotalPris`) VALUES
(1, 1, 1, 12, 2, 5000.00),
(2, 2, 2, 14, 1, 2500.00),
(3, 3, 3, 20, 3, 7500.00),
(4, 1, 4, 30, 1, 2000.00),
(5, 2, 5, 25, 2, 4000.00);

-- Insert data into `Saesonkategori`
INSERT INTO `Saesonkategori` (`KategoriID`, `Navn`, `Uger`, `Saeson`, `PrisProcent`) VALUES
(1, 'Peak Season', '[24,25,26,27,28,29,30,31,32,33,34,35]', 'super', 1.50),
(2, 'High Season', '[12,13,14,15,16,17,18,19,20,21,22,23]', 'hoej', 1.20),
(3, 'Low Season', '[1,2,3,4,5,6,7,8,9,10,11]', 'lav', 0.80),
(4, 'Mid Season', '[36,37,38,39,40,41,42,43,44,45,46,47,48]', 'medium', 1.00);

-- Insert data into `Sommerhus`
INSERT INTO `Sommerhus` (`HusID`, `EjerID`, `Lokation`, `Klassifikation`, `OmraadeID`, `StandardPris`) VALUES
(1, 1, 'Coastal Road 123', 'Luxury', 1, 2000.00),
(2, 2, 'Mountain View 45', 'Premium', 2, 1500.00),
(3, 3, 'Lakeside Retreat 9', 'Standard', 1, 1000.00),
(4, 4, 'Forest Path 22', 'Basic', 3, 800.00),
(5, 5, 'City Center 5', 'Deluxe', 4, 2500.00);

-- Insert data into `SommerhusSaesonPris`
INSERT INTO `SommerhusSaesonPris` (`StandardPris`, `SommerhusID`, `SaesonkategoriID`) VALUES
(3000.00, 1, 1),
(2400.00, 2, 2),
(800.00, 3, 3),
(1000.00, 4, 4),
(3500.00, 5, 1);

-- Insert data into `User`
INSERT INTO `User` (`UserID`, `Brugernavn`, `Adgangskode`) VALUES
(1, 'admin', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg='); -- admin:admin

-- Re-enable foreign key checks
SET FOREIGN_KEY_CHECKS = 1;
