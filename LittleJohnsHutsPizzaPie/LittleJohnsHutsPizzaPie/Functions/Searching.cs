using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LittleJohnsHutsPizzaPie.Functions
{



    public class Searching
    {

        public List<User> SearchingByName(List<User> list, string input)
        {
            List<User> found = (from a in list where a.firstName.Contains(input) select a).ToList();
           
            return found;
        }
        public List<Location> SearchingByLocation(List<Location> list, string input)
        {
            List<Location> found = (from a in list where a.address.Contains(input) select a).ToList();
           
            return found;
        }
        public List<Order> SearchingByOrder(List<Order> list, string input)
        {
            List<Order> found = (from a in list where a.IDforTheOrder.Contains(input) select a).ToList(); ;

            return found;
        }
        public void DisplalyByUser(List<Order> order)
        {
            foreach(var item in order)
            {
                Console.WriteLine(item.user.firstName);
            }
        }
        public void DisplayByLocation(List<Order> order)
        {
            foreach(var item in order)
            {
                Console.WriteLine(item.location.address);
            }
        }

    }
}


