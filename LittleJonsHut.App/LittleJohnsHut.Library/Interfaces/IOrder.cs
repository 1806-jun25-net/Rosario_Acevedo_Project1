using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IOrder
    {
        int Id { get; set; }
        DateTime OrderDate { get; set; }
        int PizzaCount { get; set; }
        decimal Price { get; set; }
        Location Location { get; set; }
        User User { get; set; }

        List<Pizza> Pizza { get; set; }
    }
}
