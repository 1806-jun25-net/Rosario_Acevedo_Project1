using LittleJohnsPizza.Library.Interfaces;
using System;
using System.Collections.Generic;

namespace LittleJohnsPizza.Library
{
    public partial class Inventory : IInventory
    {
        public int Id { get; set; }
        public string NameOfProduct { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }

        public Locations Location { get; set; }
    }
}
