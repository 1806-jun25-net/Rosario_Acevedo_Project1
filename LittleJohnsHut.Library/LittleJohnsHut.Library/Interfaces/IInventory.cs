using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface Iinventory
    {
        string address { get; set; }

        int ID { get; set; }

        int GetQuntity();
        void SetQuntity(int value);

        string NameOfProduct { get; set; }
    }
}
