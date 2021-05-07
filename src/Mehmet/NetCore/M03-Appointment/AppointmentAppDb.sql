create database AppointmentAppDb

go

use AppointmentAppDb

go

create table Client (
	Id char(11) primary key check(len(Id) = 11),
	Email nvarchar(50) unique not null,
	Phone char(14) not null
)

go

create table Appointment (
	Id int primary key identity(1, 1),
	ClientId char(11)  foreign key references Client(Id),
	Date datetime not null
)
