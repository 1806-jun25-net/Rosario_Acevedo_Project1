using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleJohnsHut.Web.Models
{
    public class WebLocation
    {
        public int? Id { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string ZipCode { get; set; }
        //public List<Inventory> Inventory { get; set; }
        //public IEnumerable<WebOrder> Orders { get; set; }
        //public List<WebUser> Users { get; set; }
    }
}
