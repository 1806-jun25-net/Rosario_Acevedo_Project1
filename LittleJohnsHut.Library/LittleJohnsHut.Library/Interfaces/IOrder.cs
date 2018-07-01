using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IOrder
    {
        string location { get; set; }
        string user { get; set; }
      

        int GetPizza_Count();
        void SetPizza_Count(int value);

        decimal Getprice();
        void Setprice(decimal value);
    }
}
