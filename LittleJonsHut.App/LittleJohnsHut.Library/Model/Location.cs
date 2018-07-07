using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Model
{
    public class Location : ILocation
    {
        public int Id { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string ZipCode { get; set; }
        public List<Inventory> Inventory { get; set ; }
        public List<Order> Orders { get; set ; }
        public List<User> Users { get; set; }
    }
}
