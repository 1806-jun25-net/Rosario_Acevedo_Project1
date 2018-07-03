using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface IInventory
    {
        int ID { get; set; }
        string NameOfTheProduct { get; set; }
        int Quantity { get; set; }
    }
}
