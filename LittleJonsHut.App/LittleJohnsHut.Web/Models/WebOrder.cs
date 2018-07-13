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
        public int locationId { get; set; }
        public int UserId { get; set; }
        public WebLocation Location { get; set; }
        public WebUser User { get; set; }
        public List<WebPizza> Pizza { get; set; }
    }
}
