
using LittleJohnsHut.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LittleJohnsHut.Library.Model
{
    public class Mapper
    {
        public static User Map(Users users) => new User
        {
            FirstName = users.FirstName,
            LastName = users.LastName, 
            Id = users.Id,  
            Order = Map(users.Orders).ToList(),
            UserName = users.UserName 
        };

        public static Users Map(User user) => new Users
        {
            FirstName = user.FirstName, 
            LastName = user.LastName, 
            Id = user.Id, 
            Orders = Map(user.Order).ToList(), 
            UserName = user.UserName 
            
        };
        public static Order Map(Orders order) => new Order
        {
            OrderDate = order.OrderDate, 
            Id = order.Id, 
            Price = order.Price,
            PizzaCount = order.PizzaCount
             
        };

        public static Orders Map(Order order) => new Orders
        {
            OrderDate = order.OrderDate,
            Id = order.Id,
            Price = order.Price,
            PizzaCount = order.PizzaCount
        };
        public static Inventory Map(DBAccess.Inventory inventory) => new Inventory
        {
            Id = inventory.Id, 
           NameOfProduct = inventory.NameOfProduct, 
           Quantity = inventory.Quantity,
    
        };
        public static DBAccess.Inventory Map(Inventory inventory) => new DBAccess.Inventory
        {
            Id = inventory.Id, 
            NameOfProduct = inventory.NameOfProduct, 
            Quantity = inventory.Quantity
        };
        public static Location Map(Locations locations) => new Location
        {
            AdressLine1 = locations.AdressLine1, 
            AdressLine2 = locations.AdressLine2, 
            Id = locations.Id, 
            ZipCode = locations.ZipCode, 
            Inventory = Map(locations.Inventory).ToList(),
            Orders = Map(locations.Orders).ToList(), 
            Users = Map(locations.Users).ToList()
            
        };
        public static Locations Map(Location locations) => new Locations
        {
            AdressLine1 = locations.AdressLine1,
            AdressLine2 = locations.AdressLine2,
            Id = locations.Id,
            ZipCode = locations.ZipCode,
            Inventory = Map(locations.Inventory).ToList(),
            Orders = Map(locations.Orders).ToList(),
            Users = Map(locations.Users).ToList()

        };
        public static Pizza Map(DBAccess.Pizza pizza) => new Pizza
        {
            Crust = pizza.Crust, 
            Id = pizza.Id, 
            NameofPizza = pizza.NameofPizza, 
            SizeOfPizza = pizza.SizeOfPizza, 
            Sauce = pizza.Sauce,
            
        };
        public static DBAccess.Pizza Map(Pizza pizza) => new DBAccess.Pizza
        {
            Crust = pizza.Crust,
            Id = pizza.Id,
            NameofPizza = pizza.NameofPizza,
            SizeOfPizza = pizza.SizeOfPizza,
            Sauce = pizza.Sauce,

        };


        public static IEnumerable<Location> Map(IEnumerable<Locations> location)  => location.Select(Map);
        public static IEnumerable<Locations> Map (IEnumerable <Location> location)  => location.Select(Map);
        public static IEnumerable<Inventory> Map(IEnumerable<DBAccess.Inventory> inventories) => inventories.Select(Map);
        public static IEnumerable<DBAccess.Inventory> Map(IEnumerable<Inventory> inventories) => inventories.Select(Map);
        public static IEnumerable<User> Map(IEnumerable<Users> users) => users.Select(Map);
        public static IEnumerable<Users> Map(IEnumerable<User> user) => user.Select(Map);
        public static IEnumerable<Order> Map(IEnumerable<Orders> order) => order.Select(Map);
        public static IEnumerable<Orders> Map(IEnumerable<Order> order) => order.Select(Map);
    }
}
