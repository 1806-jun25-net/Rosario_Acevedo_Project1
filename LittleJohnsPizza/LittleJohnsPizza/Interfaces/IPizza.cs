using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsPizza.Library.Interfaces
{
    interface IPizza
    {
        int Id { get; set; }
        string NameofPizza { get; set; }
        string Crust { get; set; }
        string Sauce { get; set; }
        int OrderId { get; set; }

        Orders Order { get; set; }
    }
}
