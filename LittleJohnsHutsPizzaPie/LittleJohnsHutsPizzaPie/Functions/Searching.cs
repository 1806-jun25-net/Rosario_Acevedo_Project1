using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Functions
{
    public class Searching
    {
      

        public static string SearchingByName(List<User> list, string input)
        {
            
            string found = "";
            foreach (var item in list)
            {
                if (item.firstName == input)
                {
                    found = input;
                }
            }
            return found;
        }

        public static List<Order> DisplayOrderByUser(List<Order> list, List<User> user)
        {
            List<Order> OrdersByUser = new List<Order>();
            foreach (var item in list)
            {
                foreach (var item2 in user)
                {
                    if (item.user == item2.firstName)
                    {
                        OrdersByUser.Add(new Order
                        {
                            location = item.location,
                            user = item.user,
                            PizzaCount = item.PizzaCount,
                            
                            price = item.price

                        });
                    }
                }
            }

            return OrdersByUser;
        }
        public static List<Order> DisplayOrderInLocation(List<Order> list, List<Location> loc)
        {
            List<Order> OrdersByLocation = new List<Order>();
            foreach (var item in list)
            {
                foreach (var item2 in loc)
                {
                    if (item.location == item2.address)
                    {
                        OrdersByLocation.Add(new Order
                        {
                            location = item.location,
                            user = item.user,
                            PizzaCount = item.PizzaCount,
                            
                            price = item.price

                        });
                    }
                }
            }
            return OrdersByLocation;
        }
    }
}
