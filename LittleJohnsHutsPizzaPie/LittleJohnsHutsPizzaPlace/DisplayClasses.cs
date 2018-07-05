using LittleJohnsHutsPizzaPie.XML;
using LittleJohnsHutsPizzaPie.Models;
using LittleJohnsHutsPizzaPie.Functions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LittleJohnsHutsPizzaPlace
{
    public class DisplayClasses
    {
        internal List<User> Session = new List<User>();
        internal DeSerilizer des = new DeSerilizer();
        internal Serilizer ser = new Serilizer();
        internal Searching search = new Searching();
        internal Sorting sort = new Sorting();


        public void populate()
        {

        }
        public void LocationsInventoryStartingLoader()
        {
            var Inventory = new List<Inventory>();
            Inventory.Add(new Inventory
            {
                IDofProduct = 1, 
                NameOfTheProduct = "Peperoni", 
                Quantity = 10000
            });
            Inventory.Add(new Inventory
            {
                IDofProduct = 2,
                NameOfTheProduct = "Cheese",
                Quantity = 10000
            });
            Inventory.Add(new Inventory
            {
                IDofProduct = 3,
                NameOfTheProduct = "Sauce",
                Quantity = 10000
            });
            Inventory.Add(new Inventory
            {
                IDofProduct = 4,
                NameOfTheProduct = "Chiken",
                Quantity = 10000
            });
            Inventory.Add(new Inventory
            {
                IDofProduct = 5,
                NameOfTheProduct = "Dough",
                Quantity = 10000
            });
            ser.SerilizeInventory("InvDate.XML", Inventory);
            var Locations = new List<Location>();
            Locations.Add(new Location{
                address = "Reston",  
                 IDofLocationStore = 1, inventory = Inventory
            });
            Locations.Add(new Location
            {
                address = "Florida",
                IDofLocationStore = 2,
                inventory = Inventory
            });
            Locations.Add(new Location
            {
                address = "Washington",
                IDofLocationStore = 3,
                inventory = Inventory
            });
            ser.SerilizerLocation("LocationDate.XML", Locations);
        }
        internal async void RegisterNameAsync()
        {
            bool loop = true;
            string loc = "";
            string input = "";
            var SearchingRef = new Searching();
            Console.WriteLine("Enter your information below: ");
            Console.WriteLine("FirstName: ");
            String fn = Console.ReadLine();
            Console.WriteLine("LastName: ");
            String LN= Console.ReadLine();
            Console.WriteLine("Choose your Location:\n" +
                "1. Reston\n2. Florida\n3. Washington \n press the number or write the city you would like to choose");
            string Choose = Console.ReadLine();
            while (loop) {
                if (Choose == "1" || Choose == "Reston")
                {
                    loc = "Reston";
                    loop = false;
                }
                else if (Choose == "2" || Choose == "Florida")
                {
                    loc = "Florida";
                    loop = false;
                }
                else if (Choose == "3" || Choose == "Washington")
                {
                    loc = "Washington";
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Try Agian or press X to Exit");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "X") { Exit(); }
                }
            }
           // LocationsInventoryStartingLoader();

            

            List<Location> AllLocations = (await des.DesLocation("LocationDate.XML")).ToList();
            List<Location> FoundLoc = SearchingRef.SearchingByLocation(AllLocations, loc);
            List<User> AllUser = new List<User>();
           
           
            try
            {
                 AllUser = (await des.DesUser("UserDate.XML")).ToList();

            }catch(Exception e)
            {
                Console.WriteLine("CongratsNewUser");
            }
            finally
            {
                AllUser.Add(new User
                {
                    firstName = fn,
                    LastName = LN,
                    location = (FoundLoc.ToArray())[0],
                   

                });
                ser.SerilizerUser("UserDate.XML", AllUser);
                AllUser = new List<User>();
            }
            
           



        }
        public IEnumerable<User> GetAllUserFromFile()
        {
            Task<IEnumerable<User>> taskUser = des.DesUser("UserDate.XML");
            IEnumerable<User> resultUser = new List<User>();
            try { resultUser = taskUser.Result; }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return resultUser;
        }
        public IEnumerable<Location> GetAllLocaitonFromFile()
        {
            Task<IEnumerable<Location>> taskUser = des.DesLocation("LocationDate.XML");
            IEnumerable<Location> resultUser = new List<Location>();
            try { resultUser = taskUser.Result; }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return resultUser;
        }
        public IEnumerable<Order> GetAllOrderFromFile()
        {
            Task<IEnumerable<Order>> taskOrder = des.DesOrder("OrderDate.XML");
            IEnumerable<Order> resultOrder = new List<Order>();
            try { resultOrder = taskOrder.Result; }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return resultOrder;
        }
        public void Exit()
        {
            Console.WriteLine("Please Come Again");
            Environment.Exit(0);
        }
        public void FirstMenuAsync()
        {
            
            Console.WriteLine("Are you a returning User press Y if you are press any Key if your not (to Exit press x)");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "y":
                    
                    var AllUser = new List<User>();
                    AllUser.AddRange(GetAllUserFromFile());
                    foreach (var item in AllUser)
                    {
                        Console.WriteLine(item.firstName + " " + item.LastName);
                    }
                    bool loop = true;
                    while (loop)
                    {
                        Console.WriteLine("write your first name to be selected\n");
                        input = Console.ReadLine();
                       

                        Session = search.SearchingByName(AllUser, input.ToLower());

                        if (!Session.Any())
                        {
                            Console.WriteLine("Try Again, try writing the name better \nto Register your Name Press Y now (press x to exit)");
                            input = Console.ReadLine();
                            if (input.ToUpper() == "Y")
                            {
                                RegisterNameAsync();
                            }
                            else if (input.ToUpper() == "X")
                            {
                                Exit();

                            }
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                    break;
                case "x":
                    Exit();
                    break;
                default:
                    RegisterNameAsync();
                    break;
            } SecondMenuAsync();
          
        }
        public void SecondMenuAsync()
        {
            var AllOrder = new List<Order>();
            AllOrder.AddRange(GetAllOrderFromFile());
            var AllUser = new List<User>();
            AllUser.AddRange(GetAllUserFromFile());
            Console.WriteLine("Wellcome: ");
                SessionOutPut(Session);
            Console.WriteLine("This is our starting menu: \n" +
                "Press 1. to Order a pizza\n" +
                "Press 2. to search users by name\n" +
                "Press 3. to display a detail of an order\n" +
                "Press 4. to display all orders history of a location\n" +
                "Press 5. to display all orders histpry of a user" +
                "Press 6. to sorting order history" +
                "press x. to exit the apication");
            string input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "1":
                    OrderingPizzaPiesAsync();
                    break;
                case "2":
                  
                    Console.WriteLine("Please enter the name of the person you are looking for");
                    input = Console.ReadLine();
                    List<User> UserList = search.SearchingByName(AllUser,input);
                    if (!UserList.Any())
                    {
                        Console.WriteLine("No Name Regiser by that name");
                        SecondMenuAsync();
                    }
                    else
                    {
                        foreach (var item in UserList)
                        {
                            Console.WriteLine(item.firstName +"\n" +
                                item.LastName + "\n" +
                                item.location.address);
                        }
                    }
                    
                    SecondMenuAsync();
                    break;
                case "3":
                   
                    Console.WriteLine("Please Enter the ID of the Order you are looking for ");
                    input = Console.ReadLine();
                    List<Order> ordersList = search.SearchingByOrder(AllOrder, input);
                    if (!ordersList.Any())
                    {
                        Console.WriteLine("No Name Regiser by that name");
                        SecondMenuAsync();
                    }
                    else
                    {
                        foreach (var item in ordersList)
                        {
                            Console.WriteLine(item.IDforTheOrder + "\n" +
                                item.price + "\n" +
                                item.PizzaCount);
                        }
                    }
                    break;
                case "4":
                   
                    search.DisplayByLocation(AllOrder);
                    break;
                case "5":
                    search.DisplalyByUser(AllOrder);
                    break;
                case "6":
                    SortingMenu();
                    break;
                case "X":
                    Exit();
                    break;
                default:
                    Console.WriteLine("wrong input try agian");
                    SecondMenuAsync();
                    break;



            }

        }

        private void SortingMenu()
        {
            var AllOrder = new List<Order>();
            AllOrder.AddRange(GetAllOrderFromFile());
            Console.WriteLine("Choose how do want to sort the list " +
                "Press 1 to sort Earliest" +
                "Press 2 to sort Lastest" +
                "Press 3 to sort Chepest " +
                "Press 4 to sort Expensive" +
                "press r to return " +
                "press x to exit ");

            var input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "1":
                   // sort.OrderEarlest(AllOrder);
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "r":
                    SecondMenuAsync();
                    break;
                case "x":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Wrong Input Try Again");
                    SortingMenu();
                    break;
            }
        }

        private void OrderingPizzaPiesAsync()
        {

            List<Order> NewOrder = new List<Order>();
            Console.WriteLine("Please insert The location where you want to order from:\n" +
                "1. Reston \n" +
                "2. Florida \n" +
                "3. Washington \n" +
                "4. X to exit \n " +
                "5. R to Return");
            var input = Console.ReadLine();
            string loc = "";
            if (input == "1" || input == "Reston")
            {
                loc = "Reston";
            }
            else if (input == "2" || input == "Florida")
            {
                loc = "Florida";
            }
            else if (input == "3" || input == "Washington")
            {
                loc = "Washington";
            }else if (input.ToUpper()== "R")
            {
                SecondMenuAsync();
            }else if (input.ToUpper() == "X")
            {
                Exit();
            }
            else
            {
                Console.WriteLine("Wrong Input Try Again");
                OrderingPizzaPiesAsync();
            }
            int n;
            bool isNumeric = false;
            do
            {
                Console.WriteLine("How many Pizzas do you want (Max is 12) press R to return and X to Exit");
                string pizzaCount = Console.ReadLine();

                isNumeric = int.TryParse(pizzaCount, out n);
                Console.WriteLine(n);
                Console.WriteLine(isNumeric);
                if (n < 12)
                {
                    isNumeric = true;
                }
                else if(n > 0)
                {
                    isNumeric = true;
                }
                else if (pizzaCount.ToUpper() == "R")
                {
                    SecondMenuAsync();
                }
                else if (pizzaCount.ToUpper() == "X")
                {
                    Exit();
                }


            } while (!isNumeric);

            decimal cost = Convert.ToDecimal( 6 * n * 0.6);
            DateTime today = DateTime.Now;

            
            List<Location> AllLocations = new List<Location>();
            AllLocations.AddRange(GetAllLocaitonFromFile());
            List<Location> FoundLoc = search.SearchingByLocation(AllLocations, loc);
           
            NewOrder.Add(new Order
            {
                
              
                DateOrder = today,
               price = cost,
                PizzaCount = n,
                location = (Location)((FoundLoc.ToArray())[0]),
                user = (User) ((Session.ToArray())[0])
            });
            ser.SerilizerOrder("OrderDate.XML", NewOrder);
            Console.ReadLine();

        }
        
        
        public void SessionOutPut(List<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"{item.firstName} {item.LastName}");
            }
        }
    }
}
