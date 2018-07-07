using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleJohnsPizza.Library.Function
{
    public class Searching
    {
        public List<Users> SearchingByName(List<Users> list, string input)
        {
            List<Users> found = (from a in list where a.FirstName.Contains(input) select a).ToList();

            return found;
        }
        public List<Locations> SearchingByLocation(List<Locations> list, string input)
        {
            List<Locations> found = (from a in list where a.AdressLine1.Contains(input) select a).ToList();

            return found;
        }
        public List<Orders> SearchingByOrder(List<Orders> list, string input)
        {
            
            List<Orders> found = (from a in list where Convert.ToString(a.Id).Contains(input) select a).ToList(); ;

            return found;
        }
        public void DisplalyByUser(List<Orders> order)
        {
            foreach (var item in order)
            {
                Console.WriteLine(item.User.FirstName);
            }
        }
        public void DisplayByLocation(List<Orders> order)
        {
            foreach (var item in order)
            {
                Console.WriteLine(item.Location.AdressLine1);
            }
        }


    }
}
