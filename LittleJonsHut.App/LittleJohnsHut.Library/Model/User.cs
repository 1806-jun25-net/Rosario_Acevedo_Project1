﻿using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Model
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int locationID { get; set; }
        public Location location { get; set; }
        public List<Order> Order { get ; set ; }
    }
}
