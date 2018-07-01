using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IInventory : ILocation
    {
        int ID { get; set; }

        int GetQuantity();
        void SetQuantity(int value);

        string NameOfProduct { get; set; }

    }
}
