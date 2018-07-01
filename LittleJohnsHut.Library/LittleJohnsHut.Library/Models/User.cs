using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class User : IUser
    {
        public string firstName { get; set; }
        public string LastName { get ; set ; }
        public string location { get ; set; }
        public DateTime hour_of_OrderPaced { get ; set; }
    }
}
