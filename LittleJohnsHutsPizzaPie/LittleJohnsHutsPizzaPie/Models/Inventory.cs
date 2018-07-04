using LittleJohnsHutsPizzaPie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Models
{
    public class Inventory : IInventory
    {
        public int IDofProduct
        {
            get { return IDofProduct; }
            set
            {
                IDofProduct += 1;
            }
        }
        public string NameOfTheProduct { get; set; }
        public int Quantity
        {
            get { return Quantity; }
            set
            {
                if (value > 0)
                {
                    Quantity = value;
                }
                else
                {
                    Quantity = 0;
                }

            }
        }
    }
}
