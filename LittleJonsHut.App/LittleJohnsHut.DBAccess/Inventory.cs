using System;
using System.Collections.Generic;

namespace LittleJohnsHut.DBAccess
{
    public partial class Inventory
    {
        public Inventory()
        {
            PizzaToopingIngrediant = new HashSet<PizzaToopingIngrediant>();
        }

        public int Id { get; set; }
        public string NameOfProduct { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }

        public Inventory IdNavigation { get; set; }
        public Locations Location { get; set; }
        public Inventory InverseIdNavigation { get; set; }
        public ICollection<PizzaToopingIngrediant> PizzaToopingIngrediant { get; set; }
    }
}
