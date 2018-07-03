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
        public Inventory inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
