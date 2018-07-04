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
            get { return IDofLocationStore; }
            set
            {
                IDofLocationStore += 1;
            }
        }
        public Inventory inventory { get; set; }
    }
}
