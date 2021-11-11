
USE LAB2_FINAL


CREATE TABLE Finders(
  FinderId INT NOT NULL IDENTITY(1,1),
  Name NVARCHAR(50) NOT NULL,
  Surname NVARCHAR(50) NOT NULL,
  Birthday VARCHAR(11)
);

ALTER TABLE Finders
ADD CONSTRAINT PK_FinderId PRIMARY KEY (FinderId)


CREATE TABLE Workers(
  WorkerId INT NOT NULL IDENTITY(1, 1),
  Name NVARCHAR(50) NOT NULL,
  Surname NVARCHAR(50) NOT NULL,
  Birthday VARCHAR(11)
);

ALTER TABLE Workers
ADD CONSTRAINT PK_WorkerId PRIMARY KEY (WorkerId)


CREATE TABLE Owners(
  OwnerId INT NOT NULL IDENTITY(1, 1),
  Name NVARCHAR(50) NOT NULL,
  Surname NVARCHAR(50) NOT NULL,
  Birthday VARCHAR(11)
);

ALTER TABLE Owners
ADD CONSTRAINT PK_OwnerId PRIMARY KEY (OwnerId)


CREATE TABLE Findings(
  FindingId INT NOT NULL IDENTITY(1,1),
  Name NVARCHAR(50) NOT NULL,
  Description NVARCHAR(100) NOT NULL
);

ALTER TABLE Findings
  ADD CONSTRAINT PK_FindingId PRIMARY KEY (FindingId);

CREATE TABLE Keywords(
  KeywordId INT NOT NULL IDENTITY(1,1),
  Word NVARCHAR(20) NOT NULL
)
ALTER TABLE Keywords
  ADD CONSTRAINT PK_KeywordId PRIMARY KEY(KeywordId) 


CREATE TABLE FindingsKeywords(
  FindingId INT NOT NULL,
  KeywordId INT NOT NULL
)

ALTER TABLE FindingsKeywords
  ADD CONSTRAINT PK_FindingId_KeywordId PRIMARY KEY(FindingId, KeywordId);

ALTER TABLE FindingsKeywords
  ADD CONSTRAINT FK_FindingsKeywords_Keywords FOREIGN KEY (KeywordId) REFERENCES Keywords(KeywordId)

ALTER TABLE FindingsKeywords
  ADD CONSTRAINT FK_FindingsKeywords_Findings FOREIGN KEY (FindingId) REFERENCES Findings(FindingId)

CREATE TABLE Extradictions(
  FindingId INT NOT NULL,
  OwnerId INT NOT NULL,
  WorkerId INT NOT NULL
);

ALTER TABLE Extradictions
  ADD CONSTRAINT PK_FindingId_OwnerId_WorkderId PRIMARY KEY(FindingId, OwnerId, WorkerId);

ALTER TABLE Extradictions
  ADD CONSTRAINT FK_Extradictions_Findings FOREIGN KEY(FindingId) REFERENCES Findings(FindingId);


ALTER TABLE Extradictions
  ADD CONSTRAINT FK_Extradictionss_Owners FOREIGN KEY(OwnerId) REFERENCES Owners(OwnerId);


ALTER TABLE Extradictions
  ADD CONSTRAINT FK_Extradictions_Workers FOREIGN KEY(WorkerId) REFERENCES Workers(WorkerId);


CREATE TABLE Obtainings(
  FindingId INT NOT NULL,
  FinderId INT NOT NULL,
  WorkerId INT NOT NULL
);

ALTER TABLE Obtainings
  ADD CONSTRAINT PK_FindingId_FinderId_WorkderId PRIMARY KEY(FindingId, FinderId, WorkerId);

ALTER TABLE Obtainings
  ADD CONSTRAINT FK_Obtainings_Findings FOREIGN KEY(FindingId) REFERENCES Findings(FindingId);


ALTER TABLE Obtainings
  ADD CONSTRAINT FK_Obtainings_Finders FOREIGN KEY(FinderId) REFERENCES Finders(FinderId);


ALTER TABLE Obtainings
  ADD CONSTRAINT FK_Obtainings_Workers FOREIGN KEY(WorkerId) REFERENCES Workers(WorkerId);

###INSERT INTO MAIN DATABASE TABLES#############################

INSERT
INTO Finders (Name, Surname, Birthday)
VALUES 
('Oleksandr', 'Logvvinov', '2002-04-03'),
('Oleksandr1', 'Logvvinov1', '2002-06-09'),
('Oleksandr1', 'Logvvinov2', '2002-07-01'),
('Oleksandr3', 'Logvvinov3', '2002-06-02'),
('Oleksandr4', 'Logvvinov4', '2002-10-12'),
('Oleksandr5', 'Logvvinov5', '2002-11-14')

INSERT 
INTO Owners (Name, Surname, Birthday)
VALUES
('Oleksii', 'Selevych', '2002-05-10'),
('Oleksii1', 'Selevych1', '2002-04-19'),
('Oleksii2', 'Selevych2', '2002-11-20'),
('Oleksii3', 'Selevych3', '2002-10-30'),
('Oleksii4', 'Selevych4', '2002-12-10'),
('Oleksii5', 'Selevych5', '2002-04-16')

INSERT
INTO Workers (Name, Surname, Birthday)
VALUES
('Artem', 'Vredniy', '2001-10-20'),
('Artem1', 'Vredniy1', '2001-10-11'),
('Artem2', 'Vredniy2', '2001-10-25'),
('Artem3', 'Vredniy3', '2001-10-05'),
('Artem4', 'Vredniy4', '2001-01-05'),
('Artem5', 'Vredniy5', '2001-09-14')


INSERT
INTO Findings (Name, Description)
VALUES
('IPhone12', 'Brand new IPhone 12 with some scratches'),
('IPhone13', 'Brand new IPhone 13 with some scratches'),
('IPhone14', 'Brand new IPhone 14 with some scratches'),
('IPhone15', 'Brand new IPhone 15 with some scratches'),
('IPhone16', 'Brand new IPhone 16 with some scratches'),
('IPhone17', 'Brand new IPhone 17 with some scratches'),
('IPhone18', 'Brand new IPhone 18 with some scratches'),
('IPhone19', 'Brand new IPhone 19 with some scratches')


INSERT 
INTO Keywords (Word)
VALUES
('Valuable'),
('Device'),
('Gold'),
('Lightweight'),
('Heavy'),
('New'),
('Old'),
('Colourful'),
('Expensive'),
('Cheap')


INSERT
INTO FindingsKeywords(FindingId, KeywordId)
VALUES
(1,1),
(2,1),
(1,3),
(1,6),
(1,2),
(2,4),
(2,6),
(2,5),
(2,8),
(3,4),
(3,1),
(3,6),
(4,1),
(4,3),
(4,7),
(5,2),
(5,5),
(5,7),
(6,1),
(6,2),
(6,3),
(7,1),
(7,4),
(7,8),
(8,1),
(8,2),
(8,6),
(8,8)

INSERT INTO Obtainings
(WorkerId, FindingId, FinderId)
VALUES
(1,1,1),
(1,2,1),
(1,3,1),
(2,4,2),
(3,5,3)


INSERT INTO Extradictions
(WorkerId, OwnerId, FindingId)
VALUES
(3,1,1),
(3,2,2),
(3,3,3),
(2,1,4)


###################DROP OR DELETE MAIN DATABASE TABLES########################
DELETE FROM Obtainings
DELETE FROM Extradictions
DELETE FROM FindingsKeywords
DELETE FROM Findings
DELETE FROM Keywords
DELETE FROM Owners
DELETE FROM Finders
DELETE FROM Workers

DROP TABLE Obtainings
DROP TABLE Extradictions
DROP TABLE FindingsKeywords
DROP TABLE Keywords
DROP TABLE Findings
DROP TABLE Finders
DROP TABLE Workers
DROP TABLE Owners


#######1st Task##############################
GO
CREATE TABLE WorkersAudits(
	ChangeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	WorkerId INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	Birthday VARCHAR(11),
	Made_At DATETIME NOT NULL,
    Operation CHAR(3) NOT NULL,
    CHECK(operation = 'INS' or operation='DEL')
)
GO
CREATE TABLE OwnersAudits(
	ChangeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	OwnerId INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Surname NVarchar(50),
	Birthday VARCHAR(11),
	Made_At DateTime NOT NULL,
	OPERATION CHAR(3) NOT NULL
	CHECK(operation = 'INS' or operation='DEL')
);
GO

CREATE TABLE FindersAudits(
	ChangeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FinderId INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Surname NVarchar(50),
	Birthday VARCHAR(11),
	Made_At DateTime NOT NULL,
	OPERATION CHAR(3) NOT NULL
	CHECK(operation = 'INS' or operation='DEL')
);

GO
CREATE TABLE FindingsAudits(
	ChangeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FindingId INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(50),
	MadeAt DateTime NOT NULL,
	OPERATION CHAR(3) NOT NULL
	CHECK(operation = 'INS' or operation='DEL')
)

GO
CREATE TABLE KeywordsAudits(
	ChangeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	KeywordId INT NOT NULL,
	Word NVARCHAR(20) NOT NULL,
	MadeAt DateTime NOT NULL,
	OPERATION CHAR(3) NOT NULL
	CHECK(operation = 'INS' or operation='DEL')
)

GO
CREATE TABLE ExtradictionsAudits(
	ChangeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FindingId INT NOT NULL,
	OwnerId INT NOT NULL,
	WorkerId INT NOT NULL,
	MadeAt DateTime NOT NULL,
	OPERATION CHAR(3) NOT NULL
	CHECK(operation = 'INS' or operation='DEL')
)
GO
CREATE TABLE ObtainingsAudits(
	ChangeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FindingId INT NOT NULL,
	FinderId INT NOT NULL,
	WorkerId INT NOT NULL,
	MadeAt DateTime NOT NULL,
	OPERATION CHAR(3) NOT NULL
	CHECK(operation = 'INS' or operation='DEL')
)

GO
CREATE TRIGGER TR_Wokers_Audits
ON Workers
AFTER INSERT, DELETE
AS
BEGIN
	INSERT INTO WorkersAudits
	(WorkerId, Name, Surname, Birthday, Made_At, Operation)
	SELECT i.WorkerId, i.Name, i.Surname, i.Birthday, GETDATE(), 'INS' FROM inserted i
	UNION ALL
	SELECT d.WorkerId, d.Name, d.Surname, d.Birthday, GETDATE(), 'DEL' FROM deleted d
END;

GO
CREATE TRIGGER TR_Owners_Audits
ON Owners
AFTER INSERT, DELETE
AS
BEGIN
	INSERT INTO OwnersAudits
	(OwnerId, Name, Surname, Birthday, Made_At, Operation)
	SELECT i.OwnerId, i.Name, i.Surname, i.Birthday, GETDATE(), 'INS' FROM inserted i
	UNION ALL
	SELECT d.OwnerId, d.Name, d.Surname, d.Birthday, GETDATE(), 'DEL' FROM deleted d
END;

GO
CREATE TRIGGER TR_Finders_Audits
ON Finders
AFTER INSERT, DELETE
AS
BEGIN
	INSERT INTO FindersAudits
	(FinderId, Name, Surname, Birthday, Made_At, Operation)
	SELECT i.FinderId, i.Name, i.Surname, i.Birthday, GETDATE(), 'INS' FROM inserted i
	UNION ALL
	SELECT d.FinderId, d.Name, d.Surname, d.Birthday, GETDATE(), 'DEL' FROM deleted d
END;

GO
CREATE TRIGGER TR_Findings_Audits
ON Findings
AFTER INSERT, DELETE
AS
BEGIN
	INSERT INTO FindingsAudits
	(FindingId, Name, Description, MadeAt, OPERATION)
	SELECT i.FindingId, i.Name, i.Description, GETDATE(), 'INS' FROM inserted i
	UNION ALL
	SELECT d.FindingId, d.Name, d.Description, GETDATE(), 'DEL' FROM deleted d
END;

GO
CREATE TRIGGER TR_Keywords_Audits
ON Keywords
AFTER INSERT, DELETE
AS
BEGIN
	INSERT INTO KeywordsAudits
	(KeywordId, Word, MadeAt, OPERATION)
	SELECT i.KeywordId, i.Word, GETDATE(), 'INS' FROM inserted i
	UNION ALL
	SELECT d.KeywordId, d.Word, GETDATE(), 'DEL' FROM deleted d
END;

GO
CREATE TRIGGER TR_Obtainings_Audits
ON Obtainings
AFTER INSERT, DELETE
AS
BEGIN
	INSERT INTO ObtainingsAudits
	(WorkerId, FinderId, FindingId, MadeAt, OPERATION)
	SELECT i.WorkerId, i.FinderId, i.FindingId, GETDATE(),'INS' FROM inserted i
	UNION ALL
	SELECT d.WorkerId, d.FinderID, d.FindingId, GETDATE(), 'DEL' FROM deleted d

END;

GO
CREATE TRIGGER TR_Extradictions_Audits
ON Extradictions
AFTER INSERT, DELETE
AS
BEGIN
	INSERT INTO ExtradictionsAudits
	(WorkerId, OwnerId, FindingId, MadeAt, OPERATION)
	SELECT i.WorkerId, i.OwnerId, i.FindingId, GETDATE(),'INS' FROM inserted i
	UNION ALL
	SELECT d.WorkerId, d.OwnerId, d.FindingId, GETDATE(), 'DEL' FROM deleted d
END;

DROP TRIGGER TR_Wokers_Audits;
DROP TRIGGER TR_Owners_Audits;
DROP TRIGGER TR_Finders_Audits;
DROP TRIGGER TR_Findings_Audits;
DROP TRIGGER TR_Keywords_Audits;
DROP TRIGGER TR_Obtainings_Audits;
DROP TRIGGER TR_Extradictions_Audits;



DELETE FROM WorkersAudits
DELETE FROM OwnersAudits
DELETE FROM FindingsAudits
DELETE FROM FindersAudits
DELETE FROM KeywordsAudits
DELETE FROM ObtainingsAudits
DELETE FROM ExtradictionsAudits


DROP TABLE WorkersAudits
DROP TABLE OwnersAudits
DROP TABLE FindingsAudits
DROP TABLE FindersAudits
DROP TABLE KeywordsAudits
DROP TABLE ObtainingsAudits
DROP TABLE ExtradictionsAudits


################2ND TASK (COPY EACH THIRD ROW)###############

GO
CREATE TRIGGER TR_Workers_Copying_Each_Third
ON Workers
AFTER UPDATE
AS
BEGIN
	DECLARE @WorkerId AS INT = (SELECT i.WorkerId FROM inserted i)
	DECLARE @RowNumer AS INT = (SELECT buf.RowNumber from Workers w INNER JOIN
	(SELECT ROW_NUMBER() OVER (Order by WorkerId) AS 'RowNumber', WorkerId FROM Workers) buf on w.WorkerId = buf.WorkerId
	WHERE w.WorkerId = @WorkerId)
	IF (@RowNumer) % 3 = 0
	BEGIN
		INSERT INTO WorkersCopy
		SELECT i.Name, i.Surname, i.Birthday FROM inserted i
	END;
END;

SELECT * FROM WorkersCopy
SELECT * FROM Workers

UPDATE Workers
SET NAME = 'Anton' WHERE WorkerId = 6

DROP TRIGGER TR_Workers_Copying_Each_Third


CREATE TABLE FindersCopy(
  FinderId INT NOT NULL IDENTITY(1,1),
  Name NVARCHAR(50) NOT NULL,
  Surname NVARCHAR(50) NOT NULL,
  Birthday VARCHAR(11)
);

ALTER TABLE FindersCopy
ADD CONSTRAINT PK_FinderId_Copy PRIMARY KEY (FinderId)


CREATE TABLE WorkersCopy(
  WorkerId INT NOT NULL IDENTITY(1, 1),
  Name NVARCHAR(50) NOT NULL,
  Surname NVARCHAR(50) NOT NULL,
  Birthday VARCHAR(11)
);

ALTER TABLE WorkersCopy
ADD CONSTRAINT PK_WorkerId_Copy PRIMARY KEY (WorkerId)


CREATE TABLE OwnersCopy(
  OwnerId INT NOT NULL IDENTITY(1, 1),
  Name NVARCHAR(50) NOT NULL,
  Surname NVARCHAR(50) NOT NULL,
  Birthday VARCHAR(11)
);

ALTER TABLE OwnersCopy
ADD CONSTRAINT PK_OwnerId_Copy PRIMARY KEY (OwnerId)


DROP TABLE OwnersCopy
DROP TABLE WorkersCopy
DROP TABLE FindersCopy


###################3RD TASK(NOT WORKING TIME INSERT)#######################

CREATE TABLE ObtainingsLogging(
	LogId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	WorkerId INT NOT NULL,
	FindingId INT NOT NULL,
	FinderId INT NOT NULL,
	LoggingTime TIME 
)



CREATE TRIGGER TR_Obtainings_Not_Working_Time 
ON Obtainings
AFTER UPDATE
AS
BEGIN
	DECLARE @t1 AS DATETIME = '1900-01-01 08:00:00.000';
	DECLARE @t2 AS DATETIME = '1900-01-01 18:00:00.000';
	IF CAST(GETDATE() AS time) NOT BETWEEN CAST(@t1 AS time) AND CAST(@t2 AS TIME)
	BEGIN
		DELETE FROM Obtainings WHERE
		WorkerId = (SELECT WorkerId from inserted) AND
		FinderId = (SELECT FinderId from inserted) AND
		FindingId = (SELECT FindingId FROM inserted)
	  
		INSERT INTO Obtainings
		(FindingId, FinderId, WorkerId)
		SELECT FindingId, FinderId, WorkerId FROM deleted

		INSERT INTO ObtainingsLogging
		SELECT WorkerId, FinderId, FindingId, CAST(GETDATE() AS TIME) FROM inserted
	END;
END;

DROP TRIGGER TR_Obtainings_Not_Working_Time
UPDATE Obtainings
SET WorkerId = 4
WHERE FindingId = 4


SELECT * FROM Obtainings
SELECT * FROM ObtainingsLogging

###################4Th TASK(LIMITED NUMBER OF EXTRADICTIONS)#######################
CREATE TRIGGER TR_Extradiction_Limited_Number_Per_Person
ON Extradictions
AFTER INSERT
AS
BEGIN
	DECLARE @NumberOfExtradictedItems AS INT;
	DECLARE @OwnerIdentifier AS INT = (SELECT OwnerId FROM inserted);
	SET @NumberOfExtradictedItems = (SELECT COUNT(*) FROM Extradictions GROUP BY OwnerId HAVING OwnerId = @OwnerIdentifier);
	IF @NumberOfExtradictedItems >=3 
	BEGIN
		DELETE FROM Extradictions
		WHERE WorkerId = (SELECT WorkerId FROM inserted)
		AND FindingId = (SELECT FindingId FROM inserted)
		AND OwnerId = @OwnerIdentifier
	END;
END;

DROP TR_Extradiction_Limited_Number_Per_Person;

SELECT * FROM Extradictions

UPDATE Extradictions
SET OwnerId = 1 WHERE OwnerId != 1

INSERT INTO Extradictions
(FindingId, OwnerId, WorkerId)
VALUES(5,1,4)



#####################################5TH TASK (OLD NEW VALUES INTO THE TABLE)
CREATE TABLE FindingsLog(
	LogId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FindingId INT NOT NULL,
	NameOld NVARCHAR(50) NOT NULL,
	NameNew NVARCHAR(50) NOT NULL,
	DescriptionOld NVARCHAR(200),
	DescriptionNew NVARCHAR(200)
)

DROP TABLE FindingsLog

CREATE TRIGGER TR_Findings_Log_Old_New_Values
ON Findings
AFTER UPDATE
AS
BEGIN
	INSERT INTO FindingsLog
	(FindingId, NameOld, NameNew, DescriptionOld, DescriptionNew)
	SELECT i.FindingId, d.Name, i.Name, d.Description, i.Description FROM deleted d, inserted i
END

DROP TRIGGER TR_Findings_Log_Old_New_Values;

SELECT * FROM Findings
SELECT * FROM FindingsLog

UPDATE Findings 
SET Description = 'some description' WHERE FindingId = 5

#################################END##############################3