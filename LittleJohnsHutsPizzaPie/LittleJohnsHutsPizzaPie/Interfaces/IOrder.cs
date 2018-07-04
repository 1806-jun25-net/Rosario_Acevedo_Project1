using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface IOrder
    {
        string IDforTheOrder { get; set; }
        Models.Location location { get; set; }
        Models.User user { get; set; }
        DateTime DateOrder { get; set;}
        decimal price { get; set; }
        int PizzaCount { get; set; }
    }
}
