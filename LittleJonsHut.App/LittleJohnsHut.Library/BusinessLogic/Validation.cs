
using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleJohnsHut.Library.BusinessLogic
{
    public class Validation
    {
        public bool UniqueUser(User Checking)
        {


            if (Checking != null)
            {
                Console.WriteLine("some one alredy has that username");

                return true;
            }
            else
            {
                return false;
            }


        }
        public bool LocationInDataBase(List<Location> loc, string v)
        {
            foreach (var item in loc)
            {
                if (item.AdressLine1 == v)
                {
                    return true;
                }
            }
            return false;

        }
        public Library.Model.Inventory FindInventoryByType(string input, List<Library.Model.Inventory> inventories)
        {
            var inv = inventories.FirstOrDefault(p => p.NameOfProduct == input);
            if (inv == null)
            {
                throw new ArgumentException($"No Such Inventroy left for this item {input}");
            }
            return inv;
        }
       public bool timeValidation(List<Orders> u)
        {
            foreach (var item in u)
            {
               var diff = DateTime.Now - item.OrderDate;
                if (diff <= TimeSpan.FromHours(2) )
                {
                    return true;
                } 

            }
            return false;

        }
        

    }
}
