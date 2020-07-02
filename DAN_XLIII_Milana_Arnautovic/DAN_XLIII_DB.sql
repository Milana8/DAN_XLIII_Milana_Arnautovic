CREATE DATABASE DAN_XLIII
 IF DB_ID('DAN_XLIII') IS NULL
CREATE DATABASE DAN_XLIII;
GO
USE DAN_XLIII;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployees')
drop table tblEmployees;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblManagers')
drop table tblRole ;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblReports')
drop table tblReports;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblRole')
drop table tblRole;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwReports')
drop view vwReports;




Create table tblManagers(
ManagerID int identity(1,1) Primary key, --Primary key
Sector nvarchar(50) not null,
AccessLevel nvarchar (50) not null,

);


Create table tblEmployees(
 EmployeeID int IDENTITY(1,1) Primary key not null, --Primary key
 FirstName nvarchar (50) not null,
 Surname nvarchar (50) not null,
 JMBG nvarchar(13) not null unique check (JMBG not like '%[^0-9]%') , --jmbg validation
 DateOfBirth date not null,
 Email varchar(50),
 AccountNumber varchar(50) NOT NULL,
 Salary INT,	
 Position varchar(50) NOT NULL,	
 Username varchar(50) UNIQUE NOT NULL,
 Pasword varchar(50)  NOT NULL,
 ManagerID int,
);

 
 
Create table tblReports(
  ReportId int identity(1,1) Primary key,
  ReportDate date not null,
  Project nvarchar (50) not null,
  WorkHours int not null,
  EmployeeID int,

);

Create table tblRole(
  RoleId int identity(1,1) Primary key,
  RoleName nvarchar (50) not null,
  
);



ALTER TABLE tblEmployees
ADD FOREIGN KEY (ManagerID) REFERENCES tblManagers(ManagerID);

ALTER TABLE tblReports
ADD FOREIGN KEY (EmployeeID) REFERENCES tblEmployees(EmployeeID);


GO

CREATE VIEW vwReports
as
SELECT r.ReportId,r.EmployeeId,CONCAT(e.FirstName, ' ', e.Surname) AS FullName,r.ReportDate, 
r.Project,e.Position,r.WorkHours
FROM tblReports r
inner join tblEmployees e
on e.EmployeeId = r.EmployeeId 

GO