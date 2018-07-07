using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsPizza.Library.Interfaces
{
    interface IUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string UserName { get; set; }
        string LastName { get; set; }
        int LocationId { get; set; }

        Locations Location { get; set; }
        ICollection<Orders> Orders { get; set; }
    }
}
