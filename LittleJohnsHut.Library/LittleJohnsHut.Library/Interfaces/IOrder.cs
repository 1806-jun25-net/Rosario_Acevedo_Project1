using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IOrder
    {
        string location { get; set; }
        string user { get; set; }
        DateTime date_Order { get; set; }
        int Pizza_Count { get; set; }
        decimal price { get; set; }

    }
}
