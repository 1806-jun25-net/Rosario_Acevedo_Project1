using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Pizza : IPizza
    {
        public string Name { get { return Name; } set
            {
                Name = "Pizza with " + topping.NameOfTheProduct;
            }
        }
        
        public string crust { get ; set ; }
        public string Sauce { get; set; }
        public Inventory topping { get ; set ; }
        public Order order { get ; set ; }
        public int IDofThePizza { get; set; }
    }
}
