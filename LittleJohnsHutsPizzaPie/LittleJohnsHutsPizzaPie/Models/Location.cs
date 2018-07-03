using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Location : ILocation
    {
        public string address { get ; set ; }
        public int ID { get; set ; }

        public List<int> quantity { get ; set ; }
        public List<string> NameOfProduct { get; set ; }
    }
}
