
using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface ILocation
    {
       int Id { get; set; }
       string AdressLine1 { get; set; }
       string AdressLine2 { get; set; }
       string ZipCode { get; set; }

        List<Inventory> Inventory { get; set; }
        List<Order> Orders { get; set; }
        List<User> Users { get; set; }
    }
}
