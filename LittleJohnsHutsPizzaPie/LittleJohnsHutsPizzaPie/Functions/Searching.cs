using LittleJohnsHutsPizzaPie.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsHutsPizzaPie.Functions
{



    public class Searching
    {

        public string SearchingByName(List<User> list, string input)
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


