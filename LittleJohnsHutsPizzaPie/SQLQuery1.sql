Create schema PizzaPlace;
Go
Create Table PizzaPlace.Users(
	ID int identity primary key, 
	FirstName NVarchar (250) not null, 
	UserName NVarchar (250) not null unique, 
	LastName NVarchar (250) not null

);

Create Table PizzaPlace.Pizza(
	ID int identity Primary key, 
	NameofPizza NVarchar(250) not null, 
	Crust NVarchar(250) not null,
	Sauce NVarchar(250) not null 


);
Create Table PizzaPlace.Locations(
	ID int identity primary key, 
	AdressLine1 NVarchar (250) not null, 
	AdressLine2 NVarchar (250) null, 
	ZipCode NVarchar (20) null, 


);



Create Table PizzaPlace.Orders(
	ID int identity  primary key,
	OrderDate date not null, 
	PizzaCount int not null, 
	Price Money not null

);
Create Table PizzaPlace.Inventory(
    ID int identity  primary key,
	NameOfProduct NVarchar(250) not null,
	Quantity int not null, 

);

Alter table PizzaPlace.Pizza
Add CONSTRAINT FK_Pizza_Order Foreign key (OrderID) REFERENCES PizzaPlace.Orders(ID); 

Alter table PizzaPlace.Orders 
add UserID int not null, 
	LocationID int not null;

Alter table PizzaPlace.Orders 
add constraint FK_Orders_User Foreign key (UserID) References PizzaPlace.Users(ID), 
	constraint FK_Orders_Location Foreign key (LocationID)References PizzaPlace.Locations(ID);

Alter table PizzaPlace.Inventory 
add LocationID int not null, 
	constraint FK_Inventory_Location Foreign key (LocationID) References PizzaPlace.Locations(ID);
Alter table PizzaPlace.Users 
add LocationID int not null, 
	constraint FK_User_Location Foreign key (LocationID) references PizzaPlace.Locations(ID);

