using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class Pizza : Interfaces.IPizza
    {
        public decimal price { get ; set; }
        public string typeOfPizza { get ; set; }
        public DateTime timeOfCreation { get; set ; }
        public string whoCreatedIt { get; set; }
        IEnumerable<Iingrediente> IPizza.ListOfIngrediant { get; set ; }
    }

   
}
