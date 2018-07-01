using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    class Inventory : IInvetory
    {
        public string typeOfIngidiante { get ; set ; }
        public int quantity { get ; set ; }
        public string Location { get ; set ; }
        public DateTime orderFromUser { get ; set ; }
        public string PizzaSold { get ; set; }
    }
}
