using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IPizza
    {
        int Id { get; set; }
        string NameofPizza { get; set; }
        string Crust { get; set; }
        string Sauce { get; set; }
        string SizeOfPizza { get; set; }
        string NameOfTooping { get; set; }
        Order Order { get; set; }
    }
}
