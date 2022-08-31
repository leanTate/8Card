use byteshark;

create table users(
	id int not null primary key identity(1,1),
	username varchar(30) not null,
	lastname varchar(30) not null,
	email varchar(45) not null,
	pass varchar(80) unique not null,
	dni int unique not null, 
	cel int unique
 );