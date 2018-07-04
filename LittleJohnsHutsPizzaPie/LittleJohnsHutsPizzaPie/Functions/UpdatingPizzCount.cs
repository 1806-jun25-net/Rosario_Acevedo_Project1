using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Functions
{
    class UpdatingPizzCount
    {
        public void InventoryCountUpdatedMin(string NameOfProductUsed, List<Inventory> inventories)
        {
            foreach (var item in inventories)
            {
                if (NameOfProductUsed == item.NameOfTheProduct)
                {
                    item.Quantity = item.Quantity--;
                }
            }
        }
        public void PizzaCountUpdatedSum(int Num, string NameOfProductUsed, List<Inventory> inventories)
        {
            foreach (var item in inventories)
            {
                if (NameOfProductUsed == item.NameOfTheProduct)
                {
                    item.Quantity = item.Quantity + Num;
                }
            }
        }
    }
}
