using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Model
{
    public class Pizza : IPizza
    {
        public int Id { get; set; }
        public string NameofPizza { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string SizeOfPizza { get; set; }
        public string NameOfTooping { get; set; }
        public Order Order { get; set; }
    }
}
