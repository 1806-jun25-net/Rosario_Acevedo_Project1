using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Location : ILocation
    {
        public string address { get; set ; }
        public int ID { get ; set ; }
       
    }
}
