using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Order : IOrder
    {
        private string location;

        public string Getlocation()
        {
            return location;
        }

        public void Setlocation(string value)
        {

            location = value;
        }

        private string User;

        public string Getuser()
        {
            return User;
        }

        public void Setuser(string value)
        {
            User = value;
        }

        public DateTime date_Order { get; set; }
        public int Pizza_Count { get; set; }
        public decimal price { get ; set; }
    }
}
