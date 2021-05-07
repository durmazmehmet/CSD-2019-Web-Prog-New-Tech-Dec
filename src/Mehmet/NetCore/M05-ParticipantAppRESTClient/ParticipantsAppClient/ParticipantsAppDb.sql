create database ParticipantsAppDb

go

create table Participant (
	Email nvarchar(50) primary key,
	Name nvarchar(200) not null,
	Date datetime not null,
	IsPartipicate bit not null,
)