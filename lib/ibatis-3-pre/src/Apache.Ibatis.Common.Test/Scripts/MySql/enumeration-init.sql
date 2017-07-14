
use iBatisNet;

drop table if exists ENUMERATIONS;

create table ENUMERATIONS
(
   ENUM_ID                        int                            not null,
   ENUM_DAY                       int                            not null,
   ENUM_COLOR                     int                            not null,
   ENUM_MONTH                     int,
   primary key (ENUM_ID)
) TYPE=INNODB;

INSERT INTO Enumerations VALUES(1, 1, 1, 128);
INSERT INTO Enumerations VALUES(2, 2, 2, 2048);
INSERT INTO Enumerations VALUES(3, 3, 4, 256);
INSERT INTO Enumerations VALUES(4, 4, 8, null);
