
use NHibernate;

drop table if exists USERS;

create table USERS
(
   LOGONID                      varchar(20)						not null default '0',
   NAME							varchar(40)                     default null,
   PASSWORD                     varchar(20)						default null,
   EMAILADDRESS                 varchar(40)						default null,
   LASTLOGON					datetime						default null,
   primary key (LOGONID)
) TYPE=INNODB;
