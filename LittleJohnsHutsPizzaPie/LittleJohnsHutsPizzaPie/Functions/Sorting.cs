using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Functions
{
    public class Sorting
    {
        public void OutPutStreamforOrders (IEnumerable<Order> list, List<Pizza> pizza)
        {
            foreach (var item in list)
            {
                Console.WriteLine("Order by" + item.user.firstName + " " + item.user.LastName +
                    "\nDate Order: " + item.DateOrder + "" +
                    "\nLocaton: " + item.location.address +
                    "\nPizzaCount: " + item.PizzaCount +
                    "\n And your Pizzas where the following: ");
                foreach (var item2 in pizza)
                {
                    if (item2.order.IDforTheOrder == item.IDforTheOrder)
                    {
                        Console.WriteLine(item2.Name);
                    }
                }
                Console.WriteLine("Total Cost: " + item.price);
            }
        }
        public void OrderEarlest(List<Order> list, List<Pizza> pizza)
        {
            var ListOrder = list.OrderBy(x => x.DateOrder);
            OutPutStreamforOrders(ListOrder, pizza); 
             
        }
        public void OrderLatest(List<Order> list, List<Pizza> pizza)
        {
            var ListOrder = list.OrderByDescending(x => x.DateOrder);
            OutPutStreamforOrders(ListOrder, pizza);

        }
        public void OrderChepest(List<Order> list, List<Pizza> pizza)
        {
           var ListOrder = list.OrderByDescending(x => x.price);
            OutPutStreamforOrders(ListOrder, pizza);

        }
        public  void OrderMostExpencive(List<Order> list, List<Pizza> pizza)
        {
            var ListOrder = list.OrderBy(x => x.price);
            OutPutStreamforOrders(ListOrder, pizza);
        }

    }
}
