using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleJohnsPizza.Library.Function
{
    public class Sort
    {
        public void OutPutStreamforOrders(IEnumerable<Orders> list, List<Pizza> pizza)
        {
            foreach (var item in list)
            {
                Console.WriteLine("Order by" + item.User.FirstName + " " + item.User.LastName +
                    "\nDate Order: " + item.OrderDate + "" +
                    "\nLocaton: " + item.Location.AdressLine1 +
                    "\nPizzaCount: " + item.PizzaCount +
                    "\n And your Pizzas where the following: ");
                foreach (var item2 in pizza)
                {
                    if (item2.Order.Id == item2.Id)
                    {
                        Console.WriteLine(item2.NameofPizza);
                    }
                }
                Console.WriteLine("Total Cost: " + item.Price);
            }
        }
        public void OrderEarlest(List<Orders> list, List<Pizza> pizza)
        {
            var ListOrder = list.OrderBy(x => x.OrderDate);
            OutPutStreamforOrders(ListOrder, pizza);

        }
        public void OrderLatest(List<Orders> list, List<Pizza> pizza)
        {
            var ListOrder = list.OrderByDescending(x => x.OrderDate);
            OutPutStreamforOrders(ListOrder, pizza);

        }
        public void OrderChepest(List<Orders> list, List<Pizza> pizza)
        {
            var ListOrder = list.OrderByDescending(x => x.Price);
            OutPutStreamforOrders(ListOrder, pizza);

        }
        public void OrderMostExpencive(List<Orders> list, List<Pizza> pizza)
        {
            var ListOrder = list.OrderBy(x => x.Price);
            OutPutStreamforOrders(ListOrder, pizza);
        }
    }
}
