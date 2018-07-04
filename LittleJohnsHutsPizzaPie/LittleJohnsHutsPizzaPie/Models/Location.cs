using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Location : ILocation
    {
        public string address { get; set; }
        public int IDofLocationStore
        {
            get;
            set;
                  }
        public List<Inventory> inventory { get; set; }
    }
}
