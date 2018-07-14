using LittleJohnsHut.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleJohnsHut.Web.Models
{
    public class WebUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public Locations location { get; set; }
        public List<Orders> Order { get; set; }
    }
}
