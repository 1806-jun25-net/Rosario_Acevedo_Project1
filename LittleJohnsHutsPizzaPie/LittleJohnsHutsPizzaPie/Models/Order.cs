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
        public decimal price { get { return price; } set { if (value > 0 && value < 501) { price = value; } }  }
        public int PizzaCount { get { return PizzaCount; }  set { if (value > 0 && value < 13) { PizzaCount = value; } }  }
        
        public DateTime DateOrder
        {
            get
            {
                return DateOrder;
            }
            set
            {
                DateOrder = DateTime.Now;
            }
        }

      
    }
}
