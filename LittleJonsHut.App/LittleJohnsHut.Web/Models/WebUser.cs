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
        public WebLocation location { get; set; }
        public List<WebOrder> Order { get; set; }
    }
}
