CREATE DATABASE Participants;

CREATE TABLE Participants (ID VARCHAR (16), Name VARCHAR (25), Surname VARCHAR (25), Age VARCHAR (10), Location VARCHAR (30));
ALTER TABLE Participants ADD Email VARCHAR (50);
ALTER TABLE Participants ADD Gender CHAR;
ALTER TABLE Participants ADD Pronouns VARCHAR(25);
ALTER TABLE Participants ADD Sexuality VARCHAR(25);
ALTER TABLE Participants ADD Photo IMAGE;
ALTER TABLE Participants ADD Preference CHAR;
ALTER TABLE Participants ALTER COLUMN Gender VARCHAR(25);

UPDATE Participants SET Pronouns = 'He/Him' WHERE ID <= 3;
UPDATE Participants SET Pronouns = 'She/Her' WHERE ID > 8;
UPDATE Participants SET Pronouns = 'They/Them' WHERE ID > 3 AND ID <= 8;
UPDATE Participants SET Gender = 'N' WHERE ID > 3 AND ID <= 8;
UPDATE Participants SET Sexuality = 'Bisexual' WHERE ID = 11;
UPDATE Participants SET Preference = 'B' WHERE Gender = 'N';
UPDATE Participants SET Preference = 'F' WHERE Gender = 'M';
UPDATE Participants SET Preference = 'M' WHERE Gender = 'F' AND ID != 11;

INSERT INTO Participants VALUES ('1','John','Gatchalian','26','Manila'); 
INSERT INTO Participants VALUES ('2','Robin','Gopez','29','Bulacan'); 
INSERT INTO Participants VALUES ('3','Adrian','Laureano','24','Pangasinan'); 
INSERT INTO Participants VALUES ('4','Raniel','Samonte','27','Manila'); 
INSERT INTO Participants VALUES ('5','Carl','Simon','32','Quezon City'); 
INSERT INTO Participants VALUES ('6','Maria','Muñoz','26','Manila'); 
INSERT INTO Participants VALUES ('7','Francine','Miranda','21','Pampanga'); 
INSERT INTO Participants VALUES ('8','Zoey','Geckoz','30','Pangasinan'); 
INSERT INTO Participants VALUES ('9','Mishy','Millare','24','Laguna');
INSERT INTO Participants VALUES ('10','Anya','Mendoza','23','Cebu'); 
INSERT INTO Participants VALUES ('11', 'Kofi', 'Doggo', '21', 'Makati', 'coffedogo@loving.com', 'F'); 

SELECT * FROM Participants;

DELETE FROM Participants WHERE Name = 'Neil';

CREATE TABLE UserLogIn (Email VARCHAR(50), Password VARCHAR(30));
INSERT INTO  UserLogIn VALUES ('coffedogo@loving.com', 'woofW00F');


SELECT * FROM UserLogIn;


CREATE TABLE MatchTable (UserEmail VARCHAR(50), MatchPartner VARCHAR(50), Notified BIT, AttractionPercent SMALLINT);
SELECT * FROM MatchTable;



SELECT Name, Surname, Age, Location, Photo FROM Participants WHERE Email IS NULL AND Gender = 'N';