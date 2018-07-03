using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Ingridiante : IIngediante
    {
        public bool Peperoni { get; set ; }
        public bool pinapple { get ; set ; }
        public bool Mashrooms { get ; set ; }
    }
}
