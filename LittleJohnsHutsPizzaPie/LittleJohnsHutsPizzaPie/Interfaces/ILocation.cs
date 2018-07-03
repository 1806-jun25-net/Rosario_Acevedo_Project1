﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Interfaces
{
    interface ILocation
    {
        string address { get; set; }
        int ID { get; set; }
        Models.Inventory inventory { get; set; }
    }
}
