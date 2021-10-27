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


SELECT * FROM Findings
SELECT * FROM Keywords
SELECT * FROM FindingsKeywords

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


INSERT 
INTO Obtainings (FindingId, FinderId, WorkerId, ActTime)
VALUES
(1, 1, 1, SYSDATETIME()),
(1, 2, 3, SYSDATETIME ())





DELETE FROM Obtainings
DELETE FROM Extradictions
DELETE FROM FindingsKeywords
DELETE FROM Findings
DELETE FROM Keywords
DELETE FROM Owners
DELETE FROM Finders
DELETE FROM Workers



