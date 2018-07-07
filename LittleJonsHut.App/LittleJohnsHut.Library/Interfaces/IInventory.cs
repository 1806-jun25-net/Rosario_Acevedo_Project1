using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    
    interface IInventory
    {
        int Id { get; set; }
        string NameOfProduct { get; set; }
        int Quantity { get; set; }
        decimal PriceOfInventory { get; set; }
        Location Location { get; set; }
    }
}
