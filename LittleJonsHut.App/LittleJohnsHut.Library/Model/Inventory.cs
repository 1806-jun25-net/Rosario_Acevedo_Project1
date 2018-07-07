using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Model
{
    public class Inventory : IInventory
    {

        public int Id { get; set; }
        public string NameOfProduct { get; set; }
        public int Quantity { get; set; }
        public decimal PriceOfInventory { get; set; }
        public Location Location { get; set; }
    }
}
