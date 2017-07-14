
use iBatisNet;

drop table if exists CATEGORIES;

create table CATEGORIES
(
   CATEGORY_ID                    int                            not null AUTO_INCREMENT,
   CATEGORY_NAME                  varchar(32),
   CATEGORY_GUID                  varchar(36),
   primary key (CATEGORY_ID)
) TYPE=INNODB;
