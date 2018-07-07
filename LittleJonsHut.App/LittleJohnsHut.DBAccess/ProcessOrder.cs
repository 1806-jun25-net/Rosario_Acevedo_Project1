using System;
using System.Collections.Generic;

namespace LittleJohnsHut.DBAccess
{
    public partial class ProcessOrder
    {
        public int Id { get; set; }
        public int? PizzaId { get; set; }
        public int? OrderId { get; set; }

        public Orders Order { get; set; }
        public Pizza Pizza { get; set; }
    }
}
