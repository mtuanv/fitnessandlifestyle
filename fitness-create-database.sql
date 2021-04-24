create table ProfileUser (
	Id int identity(1,1) primary key,
	FirstName nvarchar(255),
	LastName nvarchar(255),
	username varchar(100) not null,
	pass varchar(100) not null,
	gender bit,
	userHeight float,
	userWeight float,
	userAge int,
	email nvarchar(255) not null unique,
	phone nvarchar(255) unique
);

create table Goal(
	Id int identity(1,1) primary key,
	weightDesired float not null,
	StatusGoal bit,
	Category int not null,
	UserId int foreign key references ProfileUser(Id) not null,
);

create table GoalProgress (
	Id int identity(1,1) primary key,
	currentWeight float not null,
	currentHeight float not null,
	GoalId int foreign key references Goal(Id) not null,
);

create table WorkOut(
	Id int identity(1,1) primary key,
	Content nvarchar(255) not null,
	Title nvarchar(255) not null,
	WeightChange float not null,
	minAge int,
	maxAge int,
	Category int not null,
	ForGender bit not null,
	DayPerWeek int not null,
	ProgressTime float not null,
);

create table Exercise(
	Id int identity(1,1) primary key,
	Title nvarchar(255) not null,
	Content nvarchar(255) not null,
	Link nvarchar(255) not null,
	exerciseReps int not null,
	exersiceSets int not null,
	WorkOutId int foreign key references WorkOut(Id)
);

create table DietPlan(
	Id int identity(1,1) primary key, 
	Title nvarchar(255) not null,
	Content nvarchar(255) not null,
	Link nvarchar(255) not null,
	Category int not null,
);

create table Resources(
	Id int identity(1,1) primary key, 
	Title nvarchar(255) not null,
	Link nvarchar(255) not null,
	Content nvarchar(255) not null,
	Category int not null,
);

create table Orders(
	Id int identity(1,1) primary key,
	UserId int foreign key references ProfileUser(Id) not null,
	WorkOutId int foreign key references WorkOut(Id),
	DietPlanId int foreign key references DietPlan(Id)
);