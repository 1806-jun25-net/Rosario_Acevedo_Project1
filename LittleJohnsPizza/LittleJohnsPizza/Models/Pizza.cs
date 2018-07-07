using LittleJohnsPizza.Library.Interfaces;
using System;
using System.Collections.Generic;

namespace LittleJohnsPizza.Library
{
    public partial class Pizza : IPizza
    {
        public int Id { get; set; }
        public string NameofPizza { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public int OrderId { get; set; }

        public Orders Order { get; set; }
    }
}
