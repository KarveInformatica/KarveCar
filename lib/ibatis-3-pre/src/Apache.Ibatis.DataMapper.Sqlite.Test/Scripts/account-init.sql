CREATE TABLE IF NOT EXISTS Accounts
(
    Account_Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    Account_FirstName TEXT, 
    Account_LastName TEXT, 
    Account_Email TEXT
);

DELETE FROM Accounts;

INSERT INTO Accounts VALUES (NULL, 'Joe', 'Dalton', 'Joe.Dalton@somewhere.com');
INSERT INTO Accounts VALUES (NULL, 'Averel', 'Dalton', 'Averel.Dalton@somewhere.com');
INSERT INTO Accounts VALUES (NULL, 'William', 'Dalton', null);
INSERT INTO Accounts VALUES (NULL, 'Jack', 'Dalton', 'Jack.Dalton@somewhere.com');
INSERT INTO Accounts VALUES (NULL, 'Gilles', 'Bayon', null);