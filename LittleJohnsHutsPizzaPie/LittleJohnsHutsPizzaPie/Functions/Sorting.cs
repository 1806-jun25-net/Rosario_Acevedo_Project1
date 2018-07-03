using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Functions
{
    public class Sorting
    {
        public  IEnumerable<Order> OrderEarlest(List<Order> list)
        {
            var ListOrderEarlest = list.OrderBy(x => x.DateOrder);

            return ListOrderEarlest;
        }
        public IEnumerable<Order> OrderLatest(List<Order> list)
        {
            var ListOrderLatest = list.OrderByDescending(x => x.DateOrder);
            return ListOrderLatest;
        }
        public  IEnumerable<Order> OrderChepest(List<Order> list)
        {
            var OrderChepest = list.OrderByDescending(x => x.price);
            return OrderChepest;
        }
        public  IEnumerable<Order> OrderMostExpencive(List<Order> list)
        {
            var OrderMostExpencive = list.OrderBy(x => x.price);
            return OrderMostExpencive;
        }

    }
}
