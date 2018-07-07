using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsPizza.Library.Interfaces
{
    interface IOrder
    {
        int Id { get; set; }
        DateTime OrderDate { get; set; }
        int PizzaCount { get; set; }
        decimal Price { get; set; }
        int UserId { get; set; }
        int LocationId { get; set; }

        Locations Location { get; set; }
        Users User { get; set; }
        ICollection<Pizza> Pizza { get; set; }
    }
}
