using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Order : IOrder
    {
        public string IDforTheOrder { get; set; }
        public Location location { get ; set; }
        public User user { get ; set ; }
        public decimal price { get;  set ;  }
        public int PizzaCount { get; set; }
        
        public DateTime DateOrder
        {
            get;
            set;
        }

      
    }
}
