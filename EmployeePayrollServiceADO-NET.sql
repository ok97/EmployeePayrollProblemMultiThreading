
-- create table payroll_service(EmployeeId int identity(1,1),EmployeeName varchar(20),PhoneNumber varchar(10) NOT NULL, Address varchar(20) NOT NULL, Department varchar(20) NOT NULL,Gender char(1) NOT NULL,BasicPay float NOT NULL , Deductions float NOT NULL,TaxablePay float NOT NULL ,Tax float  NOT NULL ,NetPay float NOT NULL , StartDate DATETIME DEFAULT GETDATE(),City varchar(10) DEFAULT 'Pune',Country varchar(10) DEFAULT 'IN');
-- Create Table

create table payroll_service(EmployeeId int ,EmployeeName varchar(20),PhoneNumber varchar(10) , Address varchar(20) , Department varchar(20),Gender char(1) ,BasicPay float , Deductions float ,TaxablePay float ,Tax float, NetPay float , StartDate DATETIME ,City varchar(10) ,Country varchar(10) );
select * from payroll_service;  ---Display table



--insert Values of the table
insert into payroll_service(EmployeeId,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,NetPay,StartDate,City,Country) values('2','Om','8788616249','Nagpur','HR','M','210000','1000','100','1200','18000','2021-05-20','Pune','IN');
select * from payroll_service;  ---Display table
delete from payroll_service where EmployeeId=2;
drop table payroll_service;

 


