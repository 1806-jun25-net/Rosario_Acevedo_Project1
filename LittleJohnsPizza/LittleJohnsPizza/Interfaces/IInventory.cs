using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsPizza.Library.Interfaces
{
    interface IInventory
    {
        int Id { get; set; }
        string NameOfProduct { get; set; }
        int Quantity { get; set; }
        int LocationId { get; set; }
        Locations Location { get; set; }
    }
}
