using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleJohnsHut.Web.Models
{
    public class PizzaOrder
    {
        int PizzaCount { get; set; }
        IEnumerable<string> PizzaName { get; set; }
        int locationid { get; set; }
        int Userid { get; set; }
        WebOrder WebOrder { get; set; }
        WebLocation WebLocation { get; set; }
        WebUser WebUser{get; set;}
    }
}
