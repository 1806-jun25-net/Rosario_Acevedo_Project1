using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Store : IStore

    {
        public string Location { get ; set ; }
        public DateTime orderFromUser { get ; set ; }
        public string PizzaSold { get ; set ; }
    }
}
