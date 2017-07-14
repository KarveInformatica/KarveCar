DROP TABLE ACCOUNTS CASCADE CONSTRAINTS;

CREATE TABLE ACCOUNTS  (
   ACCOUNT_ID           INTEGER                          NOT NULL,
   ACCOUNT_FIRSTNAME    VARCHAR2(32)                     NOT NULL,
   ACCOUNT_LASTNAME     VARCHAR2(32)                     NOT NULL,
   ACCOUNT_EMAIL        VARCHAR2(128),
   CONSTRAINT PK_ACCOUNTS PRIMARY KEY (ACCOUNT_ID)
)
NOLOGGING 
NOCACHE 
NOPARALLEL;

INSERT INTO ACCOUNTS VALUES(1,'Joe', 'Dalton', 'Joe.Dalton@somewhere.com');
INSERT INTO ACCOUNTS VALUES(2,'Averel', 'Dalton', 'Averel.Dalton@somewhere.com');
INSERT INTO ACCOUNTS VALUES(3,'William', 'Dalton', null);
INSERT INTO ACCOUNTS VALUES(4,'Jack', 'Dalton', 'Jack.Dalton@somewhere.com');
INSERT INTO ACCOUNTS VALUES(5,'Gilles', 'Bayon', null);
