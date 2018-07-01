using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Order : IOrder
    {
        private int _pizza_Count;

        public string location { get; set; }
        public string user { get; set; }
        public DateTime date_Order => DateTime.Now;

        public int GetPizza_Count()
        {
            return _pizza_Count;
        }

        public void SetPizza_Count(int value)
        {
            if (value > 0 && value <= 12 )
            {
                    _pizza_Count = value;
            }
           
            
        }

        private decimal price1;

        public decimal Getprice()
        {
            return price1;
        }

        public void Setprice(decimal value)
        {
            if (value > 0 && value < 501){
                price1 = value;
            }
            
        }
    }
}
