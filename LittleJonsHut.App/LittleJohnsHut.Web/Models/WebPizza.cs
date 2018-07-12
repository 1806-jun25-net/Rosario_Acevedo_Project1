using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleJohnsHut.Web.Models
{
    public class WebPizza
    {
        public int Id { get; set; }
        public string NameofPizza { get; set; }
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public string SizeOfPizza { get; set; }
        public string NameOfTooping { get; set; }
    }
}
