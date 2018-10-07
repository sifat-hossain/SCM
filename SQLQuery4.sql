
use master
go
create database SCM
go
use SCM
go

create table Course
(
ID int identity primary key,
Name varchar(100) not null,
)


create table Batch
(
ID int identity primary key,
Name varchar(100) not null,
Start_time date not null,
Course_id int not null,
Duraion varchar(50) not null,
foreign key(Course_id) references Course(ID),
)

create table Student_info
(
ID int identity primary key,
Name varchar(100) not null,
Cell int not null unique,
Email varchar(500) not null unique,
Father_name Varchar(100) not null,
Mother_name varchar(100) not null,
Adress varchar(500) not null,
Course_id int not null,
Batch_id int not null,
Result varchar(4),
foreign key(Course_id) references Course(ID),
foreign key(Batch_id) references Batch(ID)
)



