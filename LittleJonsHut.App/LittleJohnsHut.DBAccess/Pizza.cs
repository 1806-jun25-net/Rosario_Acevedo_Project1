using System;
using System.Collections.Generic;

namespace LittleJohnsHut.DBAccess
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaToopingIngrediant = new HashSet<PizzaToopingIngrediant>();
            ProcessOrder = new HashSet<ProcessOrder>();
        }

        public int Id { get; set; }
        public string NameofPizza { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string SizeOfPizza { get; set; }

        public Pizza IdNavigation { get; set; }
        public Pizza InverseIdNavigation { get; set; }
        public ICollection<PizzaToopingIngrediant> PizzaToopingIngrediant { get; set; }
        public ICollection<ProcessOrder> ProcessOrder { get; set; }
    }
}
