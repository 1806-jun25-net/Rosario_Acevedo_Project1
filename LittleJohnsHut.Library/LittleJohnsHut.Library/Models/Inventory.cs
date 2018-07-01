using LittleJohnsHut.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHut.Library.Models
{
    class Inventory : IInventory
    {
        public int ID { get ; set ; }

        private int quantity;

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int value)
        {
            if (quantity <= 0)
            {
                quantity = 0;
            }else
            {
                quantity = value;
            }
            
        }

        public string NameOfProduct { get ; set ; }
    }
}
