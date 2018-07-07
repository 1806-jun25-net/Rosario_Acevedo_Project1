using System;
using System.Collections.Generic;

namespace LittleJohnsHut.DBAccess
{
    public partial class PizzaToopingIngrediant
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }
        public Pizza Pizza { get; set; }
    }
}
