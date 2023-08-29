create database indexing
use indexing

create table EmployeeInfromation(EmployeeID int  primary key,EmployeeName varchar(20),
EmployeeSalary int,EmployeeGender varchar(10),EmployeeCity varchar(20))

insert into EmployeeInfromation values(3,'Darshan',4500,'Male','Surat')
insert into EmployeeInfromation values(2,'Aman',80500,'Male','UP')
insert into EmployeeInfromation values(1,'Tithi',10500,'FeMale','Mehsana')
insert into EmployeeInfromation values(5,'Dhriti',2500,'FeMale','Ahemdabad')
insert into EmployeeInfromation values(4,'Rushi',90500,'Male','Nashik')

select * from EmployeeInfromation

drop table EmployeeInfromation

create clustered index IX_EmployeeInfromation
on EmployeeInfromation (EmployeeSalary desc , EmployeeGender asc)


create nonclustered index IX_EmployeeInformation
on EmployeeInfromation(EmployeeName)

select * from EmployeeInfromation where EmployeeSalary=4500

drop index EmployeeInfromation.IX_EmployeeInfromation