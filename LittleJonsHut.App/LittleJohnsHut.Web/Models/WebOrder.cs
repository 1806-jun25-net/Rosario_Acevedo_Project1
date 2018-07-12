using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleJohnsHut.Web.Models
{
    public class WebOrder
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int PizzaCount { get; set; }
        public decimal Price { get; set; }
    }
}
