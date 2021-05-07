create database carinfoappdb

go

use carinfoappdb

go

create table car_infos (
	car_info_id int primary key identity(1, 1),
	brand nvarchar(50) not null,
	model nvarchar(50) not null,
	engine_id char(20) not null,
	traffic_date date not null
)

go

insert into car_infos (brand, model, engine_id, traffic_date)
values 
('Ferrari', 'Kırmızı', '12345678', '2019-03-22'),
('Ferrari', 'Sarı', '12345679', '2019-03-23')

go

select * from car_infos where model = 'Kırmızı'



