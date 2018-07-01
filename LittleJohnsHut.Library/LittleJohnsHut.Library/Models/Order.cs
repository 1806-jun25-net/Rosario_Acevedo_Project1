using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Order : IOrder
    {
        public string location { get ; set ; }
        public string user { get; set; }
        public DateTime date_Order { get; set ; }
        public int Pizza_Count { get; set; }
        public decimal price { get; set ; }
    }
}
