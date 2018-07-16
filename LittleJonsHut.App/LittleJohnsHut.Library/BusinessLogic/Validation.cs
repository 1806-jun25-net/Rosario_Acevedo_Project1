
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Checking"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="v"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inventories"></param>
        /// <returns></returns>
        public Library.Model.Inventory FindInventoryByType(string input, List<Library.Model.Inventory> inventories)
        {
            var inv = inventories.FirstOrDefault(p => p.NameOfProduct == input);
            if (inv == null)
            {
                throw new ArgumentException($"No Such Inventroy left for this item {input}");
            }
            return inv;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
       public TimeSpan? diff { get; set; }
       public bool timeValidation(IEnumerable<Order> u)
        {
            foreach (var item in u)
            {
                diff = DateTime.Now - item.OrderDate;
                if (diff <= TimeSpan.FromHours(2) )
                {
                    return true;
                } 

            }
            return false;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal PriceValidation()
        {
            return Convert.ToDecimal((4 + 2.50 + 0.75) * 0.6);
        }

      
    }
}
