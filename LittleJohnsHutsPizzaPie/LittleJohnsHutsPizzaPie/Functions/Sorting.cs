using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Functions
{
    public class Sorting
    {
        public static List<Order> OrderEarlest(List<Order> list)
        {
            list.Sort((p1, p2) => DateTime.Compare(p1.DateOrder, p2.DateOrder));
            return list;
        }
        public List<Order> OrderLatest(List<Order> list)
        {

            return list;
        }
        public static List<Order> OrderChepest(List<Order> list)
        {
            list = list.Sort((x, y) => x.price > y.price);
            return list;
        }
        public static  List<Order> OrderMostExpencive(List<Order> list)
        {
            return list;
        }

    }
}
