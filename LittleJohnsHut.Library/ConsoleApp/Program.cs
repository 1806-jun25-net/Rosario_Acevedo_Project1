using LittleJohnsHut.Library.Models;
using System;

using System.Collections.Generic;

using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Naming();
            
           // var list = new List<Location>();
           // list.Add(new Location
           // {
           //     ID = 1,
           //     address = "reston VA"


           // });


           // Console.WriteLine("Before the method");
           // foreach ( var item in list)
           // {
           //     Console.WriteLine(item.ID +" "+item.address);
           // }
            
           // SerilizerLocation("data.xml", obj:  list);
           // Task<IEnumerable<Location>> desList = Des("data.xml");
           // IEnumerable<Location> result = new List<Location>();
           // try
           // {
           //     result = desList.Result; // synchronously sits around until the result is ready
           //     foreach ( var item in result)
           //     {
           //         Console.WriteLine(item.ID+ "  " + item.address); 
                    
           //     }
           // }
           // catch (AggregateException ex)
           // {
           //     Console.WriteLine("file wasn't found");
           // }
           //// list.AddRange(result);
           // Console.ReadLine();

        }
        public static List<User> SearchByName (List <User> list)
        {
            return list;
        }
        public static List<Order> ReturningCustomer(List<Order> list)
        {
            return list;
        }
        public static List<Order> DisplayOrderInLocation(List<Order> list)
        {
            return list;
        }
        public static List<Order> DisplayOrderByUser(List<Order> list)
        {
            return list; 
        }
        public static List<Order> OrderEarlest(List<Order> list)
        {
            return list;
        }
        public static List<Order> OrderLatest(List<Order> list)
        {
            return list;
        }
        public static List<Order> OrderChepest(List<Order> list)
        {
            return list;
        }
        public static List<Order> OrderMostExpencive(List<Order> list)
        {
            return list;
        }
        public static void Location()
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
        public static void Naming()
        {

            Console.WriteLine("Please enter your First Name");
            string fn = Console.ReadLine();
            Console.WriteLine("Please enter your Last Name");
            string ln = Console.ReadLine();
            string location = "";
            string loc = "";
            bool WrongInput = true; 
            while(WrongInput)
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
                 foreach ( var item in result)
                 {
                    list.Add(new User {
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
      

        public static void SerilizerOrder(string fileName, List<Order> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Order
                >));

            FileStream fs = null;
            Console.WriteLine("inside the method");
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                Serial.Serialize(fs, obj);

            }
            catch (IOException e)
            {
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

        }
        public static void SerilizerUser(string fileName, List<User> obj)
        {
            var Serial = new XmlSerializer(typeof(List<User
                >));

            FileStream fs = null;
            Console.WriteLine("inside the method");
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                Serial.Serialize(fs, obj);

            }
            catch (IOException e)
            {
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

        }
        public static void SerilizerInv(string fileName, List<Inventory> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Inventory
                >));

            FileStream fs = null;
            Console.WriteLine("inside the method");
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                Serial.Serialize(fs, obj);

            }
            catch (IOException e)
            {
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

        }
        public static void SerilizerPizza(string fileName, List<Pizza> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Pizza
                >));

            FileStream fs = null;
            Console.WriteLine("inside the method");
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                Serial.Serialize(fs, obj);

            }
            catch (IOException e)
            {
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

        }
        public static void SerilizerLocation(string fileName, List<Location> obj)
        {
            var Serial = new XmlSerializer(typeof(List<Location
                >));

            FileStream fs = null;
            Console.WriteLine("inside the method");
            try
            {
                fs = new FileStream(fileName, FileMode.Create);
                Serial.Serialize(fs, obj);

            }
            catch (IOException e)
            {
                Console.WriteLine($"Path not found: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }

        }
      
        public static async Task<IEnumerable<Location>> DesLocation(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Location>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Location>)serial.Deserialize(ms);
            }

        }
        public static async Task<IEnumerable<Order>> DesOrder(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Order>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Order>)serial.Deserialize(ms);
            }

        }
        public static async Task<IEnumerable<Pizza>> DesPizza(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Pizza>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Pizza>)serial.Deserialize(ms);
            }

        }
        public static async Task<IEnumerable<User>> DesUser(string fn)
        {
            var serial = new XmlSerializer(typeof(List<User>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<User>)serial.Deserialize(ms);
            }

        }
        public static async Task<IEnumerable<Inventory>> DesInv(string fn)
        {
            var serial = new XmlSerializer(typeof(List<Inventory>));


            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(fn, FileMode.Open))
                {
                    await fs.CopyToAsync(ms);
                }
                ms.Position = 0;
                return (List<Inventory>)serial.Deserialize(ms);
            }

        }
    }
    
}

