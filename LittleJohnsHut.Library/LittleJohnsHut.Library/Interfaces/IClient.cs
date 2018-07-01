using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Interfaces
{
    interface IClient : IUser 
    {
        DateTime DateAndTimeOrderWasPlace { get; set; }
        string oreder { get; set; }
        IEnumerable <string> billing_Information { get; set; }

    }
}
