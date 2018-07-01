using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IStore
    {
        
        string Location { get; set; }
        DateTime orderFromUser { get; set; }
        string PizzaSold { get; set; }

    }
}
