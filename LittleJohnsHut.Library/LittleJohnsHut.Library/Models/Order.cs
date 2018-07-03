using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Order : IOrder
    {
        public int PizzaCount
        {
            get { return PizzaCount; }
            set {
                if (value > 0 && value <= 12)
                {
                    PizzaCount = value;
                }
            }
        }

        public string location { get; set; }
        public string user { get; set; }
        public DateTime date_Order
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                date_Order = value;
            }
          
        }

        public decimal price { get { return price; } set { if (value > 0 && value < 501) { price = value; } ;} }
    }
}
