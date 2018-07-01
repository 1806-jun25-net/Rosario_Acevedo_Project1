using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IInvetory : IStore
    {

        string typeOfIngidiante { get; set; }
        int quantity { get; set; }
        

    }
}
