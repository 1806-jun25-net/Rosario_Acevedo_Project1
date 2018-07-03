using LittleJohnsHut.Library.Models;
using LittleJohnsHut.Library.XML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class MenusAndDataInput
    {
        public void PlaceOrder()
        {

        }
        public void Location()
        {
            var list = new List<Location>();
            list.Add(new Location
            {
                ID = 1,
                address = "Reston VA"
            }
           );
            list.Add(new Location
            {
                ID = 4,
                address = "Tampa FL"
            }
            );
            list.Add(new Location
            {
                ID = 5,
                address = "California LA"
            }
           );
           
            SerilizerLocation("DataLocation.XML", list);
        }
        public void Naming()
        {

            Console.WriteLine("Please enter your First Name");
            string fn = Console.ReadLine();
            Console.WriteLine("Please enter your Last Name");
            string ln = Console.ReadLine();
            string location = "";
            string loc = "";
            bool WrongInput = true;
            while (WrongInput)
            {
                Console.WriteLine("There are three Location: \n1. Reston VA \n2. Tampa FL \n3. California LA \n press the number of the desire location");

                loc = Console.ReadLine();
                if (loc.Equals("1"))
                {
                    location = "Reston VA";
                    WrongInput = false;
                }
                else if (loc.Equals("2"))
                {
                    location = "California LA";
                    WrongInput = false;
                }
                else if (loc.Equals("3"))
                {
                    location = "Tampa FL";
                    WrongInput = false;
                }
                else
                {
                    Console.WriteLine("wrong input was press try agian");
                    WrongInput = true;
                }
            }
            var list = new List<User>();
            list.Add(new User
            {
                firstName = fn,
                LastName = ln,
                location = location
            });
            Task<IEnumerable<User>> desList = DesUser("Userdata.xml");
            IEnumerable<User> result = new List<User>();
            try
            {
                result = desList.Result; // synchronously sits around until the result is ready
                foreach (var item in result)
                {
                    list.Add(new User
                    {
                        firstName = item.firstName,
                        LastName = item.LastName,
                        location = item.location
                    });

                }
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("file wasn't found");
            }

            SerilizerUser("Userdata.xml", obj: list);



        }
    }
}
