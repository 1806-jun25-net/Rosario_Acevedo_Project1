using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string UserName { get; set; }
        string LastName { get; set; }
        Location Location { get; set; }

        List<Order> Orders { get; set; }
    }
}
