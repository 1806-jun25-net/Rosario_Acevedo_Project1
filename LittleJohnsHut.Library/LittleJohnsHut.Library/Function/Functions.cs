using LittleJohnsHut.Library.Models;
using System;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LittleJohnsHut.Library.Function
{
    public class Functions
    {
        public string SearchByName(List<User> list, string input)
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
        public List<Order> DisplayOrderByUser(List<Order> list, List<User> user)
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
                            date_Order = item.date_Order,
                            price = item.price

                        });
                    }
                }
            }

            return OrdersByUser;
        }
        public List<Order> DisplayOrderInLocation(List<Order> list, List<Location> loc)
        {
            List<Order> OrdersByLocation = new List<Order>(); 
            foreach(var item in list)
            {
                foreach(var item2 in loc)
                {
                        if (item.location == item2.address)
                    {
                        OrdersByLocation.Add(new Order {
                            location = item.location,
                            user = item.user,
                            PizzaCount = item.PizzaCount,
                            date_Order = item.date_Order,
                            price = item.price

                        });
                    }
                }
            }
            return OrdersByLocation;
        }
        
        public List<Order> OrderEarlest(List<Order> list)
        {
             list.Sort((p1, p2) => DateTime.Compare(p1.date_Order, p2.date_Order));
            return list;
        }
        public List<Order> OrderLatest(List<Order> list)
        {

            return list;
        }
        public List<Order> OrderChepest(List<Order> list)
        {
            list = list.Sort((x, y) => x.price > y.price);
            return list;
        }
        public List<Order> OrderMostExpencive(List<Order> list)
        {
            return list;
        }
       

    }
}
