using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    public class User : IUser

    {
        public string name { get ; set ; }
        public string address_Line1 { get ; set ; }
        public string address_Line2 { get ; set ; }
        public string ZipCode { get ; set; }
    }
}
