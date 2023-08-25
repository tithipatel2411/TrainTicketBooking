create database TrainTicketBooking

use TrainTicketBooking

create table UserDetail(UserId int  primary key,
UserName varchar(20),Gender varchar(10),Age int ,Wallet int)

insert into UserDetail values('Darshan','Male',1200)

select * from UserDetail

exec InsertUserDetail 2,Shreyanshi,Female,33,3000,I
-----------------------------------------------------------------------------------------------------


create table UserMapping(UserMapId int  primary key,UserId int foreign key references UserDetail(UserId),
[Source] int foreign key references LocationMap(LocationId),[Destination] int foreign key references LocationMap(LocationId),
CancelBooking varchar(5))

insert into UserMapping values(4,504,505)

select * from UserMapping

---------------------------------------------------------------------------------------------------------------------------------

create table TrainDetail(TrainId int  primary key ,
TrainNo int,TrainName varchar(20),TrainSourceId int foreign key references LocationMap(LocationId),
TrainDestinationId int foreign key references LocationMap(LocationId),Availibility varchar(5))

insert into TrainDetail values(1004,'Tejas',504,505,250)


select * from TrainDetail

-----------------------------------------------------------------------------------------------------------------------------

create table LocationMap(LocationId int  primary key,LocationName varchar(30))

insert into LocationMap values(505,'Surat')


select * from LocationMap

-------------------------------------------------------------------------------------------------------------------------------------

create table Booking(BookingId int  primary key,UserMapId int foreign key references UserMapping(UserMapId) ,
TrainId int foreign key references TrainDetail(TrainId),PaymentId int foreign key references Payment(PaymentId) ,Amount int ,
BookingDate datetime default getdate())

insert into Booking values(101,204,50)


select * from Booking

--------------------------------------------------------------------------------------------------------------------------------------

create table Payment(PaymentId int primary key , PaymentType varchar(20))


select * from Payment



