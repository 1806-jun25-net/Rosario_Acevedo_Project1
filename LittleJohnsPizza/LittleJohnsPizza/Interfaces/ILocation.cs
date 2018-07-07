using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsPizza.Library.Interfaces
{
    interface ILocation
    {
        int Id { get; set; }
        string AdressLine1 { get; set; }
        string AdressLine2 { get; set; }
        string ZipCode { get; set; }

        ICollection<Inventory> Inventory { get; set; }
        ICollection<Orders> Orders { get; set; }
        ICollection<Users> Users { get; set; }
    }
}
