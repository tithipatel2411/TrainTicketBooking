create table UserDetail(UserId int  primary key,
UserName varchar(20),
Gender varchar(10),
Age int ,
Wallet int)


create table UserMapping(UserMapId int  primary key,
UserId int foreign key references UserDetail(UserId),
[Source] int foreign key references LocationMap(LocationId),
[Destination] int foreign key references LocationMap(LocationId))


create table TrainDetail(TrainId int  primary key ,
TrainNo int,TrainName varchar(20),
TrainSourceId int foreign key references LocationMap(LocationId),
TrainDestinationId int foreign key references LocationMap(LocationId),
TotalSeat int,
Availibility varchar(5))



create table LocationMap(LocationId int  primary key,
TrainId int foreign key references TrainDetail(TrainId) ,
LocationName varchar(30))


create table Booking(BookingId int  primary key,
UserMapId int foreign key references UserMapping(UserMapId) ,
TrainId int foreign key references TrainDetail(TrainId),
PaymentId int foreign key references Payment(PaymentId) ,
TicketAmount int ,
CancelBooking int,
TicketStatus int ,
BookingDate datetime default getdate())


create table Payment(PaymentId int primary key ,
PaymentType varchar(20))
