using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Model
{
    public class Order : IOrder 
    {
        public int Id { get; set; }
        public string OrderDate { get; set ; }
        public int PizzaCount { get ; set ; }
        public decimal Price { get ; set ; }
        public int locationId { get; set; }
        public int UserId { get; set; }
        public Location Location { get; set ; }
        public User User { get; set; }
        public List<Pizza> Pizza { get; set; }


    }
}
