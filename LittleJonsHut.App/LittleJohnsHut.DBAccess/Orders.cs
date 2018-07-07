using System;
using System.Collections.Generic;

namespace LittleJohnsHut.DBAccess
{
    public partial class Orders
    {
        public Orders()
        {
            ProcessOrder = new HashSet<ProcessOrder>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int PizzaCount { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }

        public Locations Location { get; set; }
        public Users User { get; set; }
        public ICollection<ProcessOrder> ProcessOrder { get; set; }
    }
}
