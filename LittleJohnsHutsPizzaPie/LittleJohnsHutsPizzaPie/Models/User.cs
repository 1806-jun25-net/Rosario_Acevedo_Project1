using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class User : IUser
    {
        public int IDofTheUser { get { return IDofTheUser; } set { IDofTheUser += 1; } }
        public string firstName { get ; set ; }
        public string LastName { get ; set ; }
        public Location location { get ; set ; }
       
    }
}
