using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IOrder
    {
        string Getlocation();
        void Setlocation(string value);

        string Getuser();
        void Setuser(string value);

        DateTime date_Order { get; set; }
        int Pizza_Count { get; set; }
        decimal price { get; set; }

    }
}
