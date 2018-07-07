using LittleJohnsPizza.Library.Interfaces;
using System;
using System.Collections.Generic;

namespace LittleJohnsPizza.Library
{
    public partial class Orders : IOrder
    {
        public Orders()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int PizzaCount { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }

        public Locations Location { get; set; }
        public Users User { get; set; }
        public ICollection<Pizza> Pizza { get; set; }
    }
}
