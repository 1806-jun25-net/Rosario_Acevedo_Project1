using LittleJohnsPizza.Library.Interfaces;
using System;
using System.Collections.Generic;

namespace LittleJohnsPizza.Library
{
    public partial class Locations : ILocation
    {
        public Locations()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
