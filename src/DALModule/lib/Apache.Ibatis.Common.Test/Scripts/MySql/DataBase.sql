use mysql;

drop database iBatisNet;
create database iBatisNet;

drop database NHibernate;
create database NHibernate;

grant all privileges on iBatisNet.* to IBatisNet@'%' identified by 'test';
grant all privileges on iBatisNet.* to IBatisNet@localhost identified by 'test';
grant all privileges on iBatisNet.* to IBatisNet@localhost.localdomain identified by 'test';

grant all privileges on NHibernate.* to NHibernate@'%' identified by 'test';
grant all privileges on NHibernate.* to NHibernate@localhost identified by 'test';
grant all privileges on NHibernate.* to NHibernate@localhost.localdomain identified by 'test';


/*==============================================================*/
/* Nom de la base :  MYSQL                                      */
/* Nom de SGBD :  MySQL 3.23                                    */
/* Date de création :  27/05/2004 20:51:40                      */
/*==============================================================*/

use iBatisNet;

drop table if exists ACCOUNTS;

drop table if exists CATEGORIES;

drop table if exists ENUMERATIONS;

drop table if exists LINEITEMS;

drop table if exists ORDERS;

drop table if exists OTHERS;

/*==============================================================*/
/* Table : ACCOUNTS                                             */
/*==============================================================*/
create table ACCOUNTS
(
   ACCOUNT_ID                     int                            not null,
   ACCOUNT_FIRSTNAME              varchar(32)                    not null,
   ACCOUNT_LASTNAME               varchar(32)                    not null,
   ACCOUNT_EMAIL                  varchar(128),
   primary key (ACCOUNT_ID)
) TYPE=INNODB;

/*==============================================================*/
/* Table : CATEGORIES                                           */
/*==============================================================*/
create table CATEGORIES
(
   CATEGORY_ID                    int                            not null AUTO_INCREMENT,
   CATEGORY_NAME                  varchar(32),
   CATEGORY_GUID                  varchar(36),
   primary key (CATEGORY_ID)
) TYPE=INNODB;

/*==============================================================*/
/* Table : ENUMERATIONS                                         */
/*==============================================================*/
create table ENUMERATIONS
(
   ENUM_ID                        int                            not null,
   ENUM_DAY                       int                            not null,
   ENUM_COLOR                     int                            not null,
   ENUM_MONTH                     int,
   primary key (ENUM_ID)
) TYPE=INNODB;

/*==============================================================*/
/* Table : LINEITEMS                                            */
/*==============================================================*/
create table LINEITEMS
(
   LINEITEM_ID                    int                            not null,
   ORDER_ID                       int                            not null,
   LINEITEM_CODE                  varchar(32)                    not null,
   LINEITEM_QUANTITY              int                            not null,
   LINEITEM_PRICE                 decimal(18,2),
   LINEITEM_PICTURE					blob,
   primary key (ORDER_ID, LINEITEM_ID)
) TYPE=INNODB;

/*==============================================================*/
/* Table : ORDERS                                               */
/*==============================================================*/
create table ORDERS
(
   ORDER_ID                       int                            not null,
   ACCOUNT_ID                     int                            not null,
   ORDER_DATE                     datetime,
   ORDER_CARDTYPE                 varchar(32),
   ORDER_CARDNUMBER               varchar(32),
   ORDER_CARDEXPIRY               varchar(32),
   ORDER_STREET                   varchar(32),
   ORDER_CITY                     varchar(32),
   ORDER_PROVINCE                 varchar(32),
   ORDER_POSTALCODE               varchar(32),
   ORDER_FAVOURITELINEITEM        int,
   primary key (ORDER_ID)
) TYPE=INNODB;

/*==============================================================*/
/* Table : OTHERS                                               */
/*==============================================================*/
create table OTHERS
(
   OTHER_INT                       int,
   OTHER_LONG                     bigint
) TYPE=INNODB;



use NHibernate;

drop table if exists USERS;

/*==============================================================*/
/* Table : USERS                                                */
/*==============================================================*/
create table USERS
(
   LOGONID                      varchar(20)						not null default '0',
   NAME							varchar(40)                     default null,
   PASSWORD                     varchar(20)						default null,
   EMAILADDRESS                 varchar(40)						default null,
   LASTLOGON					datetime						default null,
   primary key (LOGONID)
) TYPE=INNODB;
