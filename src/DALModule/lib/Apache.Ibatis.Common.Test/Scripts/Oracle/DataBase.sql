/*==============================================================*/
/* Nom de la base :  ORACLE                                     */
/* Nom de SGBD :  ORACLE Version 9i                             */
/* Date de création :  27/05/2004 20:55:37                      */
/*==============================================================*/


DROP TABLE ACCOUNTS CASCADE CONSTRAINTS;

DROP TABLE CATEGORIES CASCADE CONSTRAINTS;

DROP TABLE ENUMERATIONS CASCADE CONSTRAINTS;

DROP TABLE LINEITEMS CASCADE CONSTRAINTS;

DROP TABLE ORDERS CASCADE CONSTRAINTS;

DROP TABLE OTHERS CASCADE CONSTRAINTS;

DROP SEQUENCE S_CATEGORIES;

CREATE SEQUENCE S_CATEGORIES
  START WITH 1
  MAXVALUE 1E27
  MINVALUE 1
  NOCYCLE
  CACHE 20
  NOORDER;

/*==============================================================*/
/* Table : ACCOUNTS                                             */
/*==============================================================*/


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

/*==============================================================*/
/* Table : CATEGORIES                                           */
/*==============================================================*/


CREATE TABLE CATEGORIES  (
   CATEGORY_ID          NUMBER(6)                        NOT NULL,
   CATEGORY_NAME        VARCHAR2(32),
   CATEGORY_GUID        VARCHAR2(36)
)
NOLOGGING
NOCACHE
NOPARALLEL;

/*==============================================================*/
/* Table : ENUMERATIONS                                         */
/*==============================================================*/


CREATE TABLE ENUMERATIONS  (
   ENUM_ID              INTEGER                          NOT NULL,
   ENUM_DAY             INTEGER                          NOT NULL,
   ENUM_COLOR           INTEGER                          NOT NULL,
   ENUM_MONTH           INTEGER,
   CONSTRAINT PK_ENUMERATIONS PRIMARY KEY (ENUM_ID)
)
NOLOGGING
NOCACHE
NOPARALLEL;

/*==============================================================*/
/* Table : LINEITEMS                                            */
/*==============================================================*/


CREATE TABLE LINEITEMS  (
   LINEITEM_ID          INTEGER                          NOT NULL,
   ORDER_ID             INTEGER                          NOT NULL,
   LINEITEM_CODE        VARCHAR2(32)                     NOT NULL,
   LINEITEM_QUANTITY    INTEGER                          NOT NULL,
   LINEITEM_PRICE       NUMBER(18,2),
   LINEITEM_PICTURE		BLOB,
   CONSTRAINT PK_LINEITEMS PRIMARY KEY (ORDER_ID, LINEITEM_ID)
)
NOLOGGING
NOCACHE
NOPARALLEL;

/*==============================================================*/
/* Table : ORDERS                                               */
/*==============================================================*/


CREATE TABLE ORDERS  (
   ORDER_ID             INTEGER                          NOT NULL,
   ACCOUNT_ID           INTEGER                          NOT NULL,
   ORDER_DATE           DATE,
   ORDER_CARDTYPE       VARCHAR2(32),
   ORDER_CARDNUMBER     VARCHAR2(32),
   ORDER_CARDEXPIRY     VARCHAR2(32),
   ORDER_STREET         VARCHAR2(32),
   ORDER_CITY           VARCHAR2(32),
   ORDER_PROVINCE       VARCHAR2(32),
   ORDER_POSTALCODE     VARCHAR2(32),
   ORDER_FAVOURITELINEITEM INTEGER,
   CONSTRAINT PK_ORDERS PRIMARY KEY (ORDER_ID)
)
NOLOGGING
NOCACHE
NOPARALLEL;

/*==============================================================*/
/* Table : OTHERS                                               */
/*==============================================================*/


CREATE TABLE OTHERS (
	OTHER_INT INT NULL ,
	OTHER_LONG INT NULL
)
NOLOGGING
NOCACHE
NOPARALLEL;
