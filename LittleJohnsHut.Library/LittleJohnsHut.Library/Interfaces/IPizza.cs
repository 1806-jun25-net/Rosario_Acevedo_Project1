using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IPizza
    {
         decimal price { get; set; } 
         string typeOfPizza { get; set; }
         DateTime timeOfCreation { get; set; }
         string whoCreatedIt { get; set; }
         IEnumerable<Iingrediente> ListOfIngrediant { get; set; }
         
    }
}
