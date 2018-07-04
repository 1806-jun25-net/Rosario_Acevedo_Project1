using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Inventory : IInventory
    {
        public int IDofProduct
        {
            get;
            set;
            
        }
        public string NameOfTheProduct { get; set; }
        public int Quantity
        {
            get;
            set;
        }
    }
}
