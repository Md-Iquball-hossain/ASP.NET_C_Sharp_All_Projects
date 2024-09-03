
create table Travelagents
(
AgentId int identity primary key,
AgentName varchar(40) not null
)
go

create table TourePackages
(
PackageId int identity primary key,
PackageName varchar(30) not null,
PackageCatagory varchar(30) not null,
PackageCost money not null,
Active bit not null,
Touredate date not null,
AgentId int references Travelagents(AgentId )
)
go
create table Tourists 
(
TouristId int identity primary key,
TouristName varchar(40) not null,
TouristOcupation varchar(30) not null,
[Email] nvarchar(100) not null,
Picture nvarchar(30) not null,
PackageId int references Tourepackages(PackageId)
)

go
create table Hotels
(
HotelId int identity primary key,
HotelName varchar(20)not null,
[Address] nvarchar(100) not null,
BookingDate date not null,
TouristId int references Tourists(TouristId),

)
go

create table Transports
(
TransportId int identity primary key,
TransportCompany varchar(20) not null,
TransportType varchar(20) not null,
FormCity varchar(50) not null,
AgentId int references Travelagents(AgentId )
)
