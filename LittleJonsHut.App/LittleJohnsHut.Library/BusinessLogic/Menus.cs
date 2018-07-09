using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Model;
using LittleJohnsHut.Library.Repository;
using LittleJohnsHut.Library.XML;
using LittleJohnsPizza.Library.XML;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LittleJohnsHut.Library
{
    /// <summary>
    /// This class is created to take all the users input
    /// also contins various clases that calcualte and search in the data base
    /// </summary>
    public class Menus
    {
        /// <summary>
        /// Get the session of the user 
        /// </summary>
        public User Session { get; set; }
        /// <summary>
        /// This class is use to Register the User  and also checks if the user has a unique Username 
        /// </summary>
        public void Register()
        {

            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
            Console.WriteLine("Please enter your First name");
            string fn = Console.ReadLine();
            Console.WriteLine("Please enter your Last Name");
            string ln = Console.ReadLine();
            Console.WriteLine("Please enter a Unique UserName");
            string un = Console.ReadLine();
            Console.WriteLine("Please enter a Location, here is a list of our locations");
            List<Location> loc = repo.DisplayLocation().ToList();
            int c = 0;
            foreach (var item in loc)
            {
                c++;
                Console.WriteLine($"Location {c}:{item.AdressLine1}");
            }
            string address = Console.ReadLine();
            var LocationValidation = repo.FindLocationByAdrress(address);
            if (LocationValidation == null)
            {
                Console.WriteLine("Wrong input please try agian ");
                Register();
            }


            repo.RegisterUser(fn, ln, un, address);
            repo.Save();

            session(repo.FindUserByName(un));
            Session = repo.FindUserByName(un);
            ContinuesMenu();

        }

        public void RetruningClient()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));


            Console.WriteLine("Write your User Name: ");
            string input = Console.ReadLine();
            User users = repo.FindUserByName(input);
            if (users == null)
            {
                Console.WriteLine("try Agian ");
                RetruningClient();
            }

            session(users);
            Session = repo.FindUserByName(users.UserName);
            ContinuesMenu();

        }
        public void session(User user)
        {
            Serilize ser = new Serilize();
            ser.SerilizerSession("RemeberSession.XML", user);
        }
        public void StartingMenu()
        {
            Console.WriteLine("Are you a retunring customer? press Y to Yes press N to register, press X to Exit, Press F for fast Log in");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                RetruningClient();
            }
            else if (input.ToUpper() == "N")
            {
                Register();
            }
            else if (input.ToUpper() == "X")
            {
                Exit();
            }else if (input.ToUpper() == "F")
            {
                FastEntry();
                ContinuesMenu();
            }
            else
            {
                Console.WriteLine("WrongInput");
                StartingMenu();
            }

        }
        public void FastEntry()
        {
            DeSerilize ser = new DeSerilize();

            Session = ser.DesSession("RemeberSession.XML").Result;
        }
        public void ContinuesMenu()
        {
            Console.WriteLine($"Welcome :{Session.FirstName} {Session.LastName}");
            Console.WriteLine($"Plese Choose a option press the number on the left of the option \n" +
                $"1. Order your pizza\n" +
                $"2. Sorting and adminstrating\n " +
                $"3. Searching by a catagory\n" +
                $"4. Exit your application");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    OrderMenu();
                    break;
                case "2":
                    SortingMenu();
                    break;
                case "3":
                    SearchingMenu();
                    break;
                case "4":
                    Exit();
                    break;

                default:
                    Console.WriteLine("wrong input try agian");
                    ContinuesMenu();
                    break;
            }

        }
        public void SearchingMenu()
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));

            Console.WriteLine("Enter what you want to search for:" +
                "1. Search for User" +
                "2. Search for Order " +
                "3. Go Back" +
                "4. Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Please Enter your User Name");
                    input = Console.ReadLine();
                    User user = repo.FindUserByName(input);
                    if (user == null)
                    {
                        Console.WriteLine("Wrong input try again");
                        SearchingMenu();
                    }
                    else
                    {
                        var loc = repo.FindLocationByID(user.locationID);
                        Console.WriteLine($"First Name: {user.FirstName} \n " +
                            $"Last Name: {user.LastName}\n " +
                            $"User Name: {user.UserName}\n " +
                            $"Address: {loc.AdressLine1}");
                        ContinuesMenu();
                    }
                    break;
                case "2":
                    Console.WriteLine("Please Enter your Order ID");
                    input = Console.ReadLine();
                    int i = 0;
                    try
                    {
                        i = Convert.ToInt32(input);
                    }
                    catch (Exception e) { Console.WriteLine("Wrong input try again"); SearchingMenu(); }

                    Order o = repo.FindUserByOrderID(i);

                    if (o == null)
                    {
                        Console.WriteLine("Wrong input try again");
                        SearchingMenu();
                    }
                    else
                    {
                        Console.WriteLine($"ID: {o.Id} \n " +
                            $"Date : {o.OrderDate}\n " +
                            $"Pizzas: {o.PizzaCount}\n ");

                        ContinuesMenu();
                    }
                    break;
                case "3":
                    ContinuesMenu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    SearchingMenu();
                    break;

            }
        }
        public void SortingMenu()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
            Console.WriteLine("do you want to use your location? press Y for yes and N for no ");
            Console.WriteLine("Choose the sort you want to implement \n" +
                "1. Sort by order history by earliest \n" +
                "2. Sort by order history by latest \n" +
                "3. Sort by order history by cheapest\n" +
                "4. Sort by order history by most expensive \n" +
                "5. return to main menu \n" +
                "6. exit the aplication");

            string inpt = Console.ReadLine();
            var i = new List<Order>();
            switch (inpt)
            {
                case "1":
                     i = repo.DiplayEarliest().ToList();
                    break;
                case "2":
                    i = repo.DiplayLatest().ToList();
                    break;
                case "3":
                    i = repo.DiplayCheapest().ToList();
                    break;
                case "4":
                    i = repo.DiplayMostExpencive().ToList();
                    break;
                case "5":
                    ContinuesMenu();
                    break;
                case "6":
                    Exit();
                    break;
                default:
                    SortingMenu();
                    break;
            }
            foreach (var item in i)
            {
                Console.WriteLine($"Pizza in order: {item.PizzaCount}\n" +
                    $"Price: {item.Price}\n" +
                    $"Order Date: {item.OrderDate}");
            }
            ContinuesMenu();
        }
        decimal cost = Convert.ToDecimal((4 + 2.50 + 0.75) * 0.6);
        public void OrderMenu()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
            Console.WriteLine("do you want to use your location? press Y for yes and N for no ");
            string input = Console.ReadLine();
            var loc = new Location();
            if (input.ToUpper() == "Y")
            {

                loc = repo.FindLocationByID(Session.locationID);

            }
            else if (input.ToUpper() == "N")
            {
                Console.WriteLine("Please enter a Location, here is a list of our locations");
                List<Location> locs = repo.DisplayLocation().ToList();
                int c = 0;
                foreach (var item in locs)
                {
                    c++;
                    Console.WriteLine($"Location {c}:{item.AdressLine1}");
                }
                string address = Console.ReadLine();
                loc = repo.FindLocationByAdrress(address);
                if (loc == null)
                {
                    Console.WriteLine("Wrong input please try agian ");
                    OrderMenu();
                }
            }
            else
            {
                OrderMenu();
            }


            Console.WriteLine("Please enter the amount of pizza you want");
            int p = 0;
            var PC = Console.ReadLine();
            try
            {
                p = Convert.ToInt32(PC);
            }
            catch (Exception e)
            {
                OrderMenu();
            }
            InvLocation = loc;
            cost = cost * p;
            if (cost < 0 || cost > 500)
            {
                OrderMenu();

            }
            if (p <= 0 || p >= 13)
            {
                OrderMenu();
            }
            DateTime DO = DateTime.Now;
            for (int i = 0; i < p; i++)
            {
                PizzaMaker();
                cost += cost;
            }
            repo.ordering(cost, DO, p, loc.AdressLine1, Session.UserName);
            repo.Save();
            ContinuesMenu();
        }
        private Location InvLocation { get; set; }
        public void PizzaMaker()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
            Console.WriteLine("Please choose your pizza from our selection");
            var pizza = repo.DisplayPizza();
            foreach (var item in pizza)
            {
                Console.WriteLine(item.NameofPizza);
            }
            string input = Console.ReadLine();
            var piz = repo.FindPizzaByName(input);
            if (piz == null)
            {
                PizzaMaker();
            }
            var InvetoryOfLocation = repo.findingInvetoryByLocationID(InvLocation.Id);
            Console.WriteLine(piz.Id);
            var MaipulatingInventoryChesse = FindInventoryByType("Cheese", InvetoryOfLocation);
            var MaipulatingInventoryDough = FindInventoryByType("Dough", InvetoryOfLocation);
            var MaipulatingInventorySauce = FindInventoryByType("Sauce", InvetoryOfLocation);
            repo.creatingPizza(MaipulatingInventoryChesse.Id, piz.Id);
            repo.creatingPizza(MaipulatingInventoryDough.Id, piz.Id);
            repo.creatingPizza(MaipulatingInventorySauce.Id, piz.Id);
            switch (input)
            {
                case "Pizza Peperoni":
                    var MaipulatingInventoryPeperoni = FindInventoryByType("Peperoni", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryPeperoni.Id, piz.Id);
                    cost = cost + Convert.ToDecimal(0.50);

                    break;

                case "Pizza Suprema":
                    var MaipulatingInventoryBacon3 = FindInventoryByType("Bacon", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryBacon3.Id, piz.Id);
                    var MaipulatingInventoryHam3 = FindInventoryByType("Ham", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryHam3.Id, piz.Id);
                    var MaipulatingInventoryVeggie3 = FindInventoryByType("Veggie", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryVeggie3.Id, piz.Id);
                    var MaipulatingInventoryPeperoni2 = FindInventoryByType("Peperoni", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryPeperoni2.Id, piz.Id);
                    cost = cost + Convert.ToDecimal(1.50);
                    break;


                case "Pizza Mashroom":
                    var MaipulatingInventoryVeggie = FindInventoryByType("Veggie", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryVeggie.Id, piz.Id);
                    cost = cost + Convert.ToDecimal(.50);

                    break;
                case "Pizza MeatlLover":
                    var MaipulatingInventoryBacon2 = FindInventoryByType("Bacon", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryBacon2.Id, piz.Id);
                    var MaipulatingInventoryHam2 = FindInventoryByType("Ham", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryHam2.Id, piz.Id);
                    cost = cost + Convert.ToDecimal(1.00);

                    break;
                case "Pizza veggi":
                    var MaipulatingInventoryVeggie2 = FindInventoryByType("Veggie", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryVeggie2.Id, piz.Id);
                    cost = cost + Convert.ToDecimal(0.50);
                    break;
                case "Pizza Beacon":
                    var MaipulatingInventoryBacon = FindInventoryByType("Bacon", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryBacon.Id, piz.Id);
                    cost = cost + Convert.ToDecimal(0.50);
                    break;
                case "Pizza Ham ":
                    var MaipulatingInventoryHam = FindInventoryByType("Ham", InvetoryOfLocation);
                    repo.creatingPizza(MaipulatingInventoryHam.Id, piz.Id);
                    cost = cost + Convert.ToDecimal(0.50);
                    break;
            }
            repo.Save();
           
        }
        public Library.Model.Inventory FindInventoryByType(string input, List<Library.Model.Inventory> inventories)
        {
            var inv = inventories.FirstOrDefault(p => p.NameOfProduct == input);
            if (inv == null)
            {
                throw new ArgumentException($"No Such Inventroy left for this item {input}");
            }
            return inv;
        }
        public void Exit()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
            
            Serilize ser = new Serilize();

            ser.SerilizeInventory("BackupInventory.XML", repo.DisplayInventory().ToList() );
            ser.SerilizerLocation("BackUpLocations.XML", repo.DisplayLocation().ToList());
            ser.SerilizerOrder("BackUpOrder.XML", repo.DisplayOrder().ToList());
            ser.SerilizerPizza("BackUpPizza.XML", repo.DisplayPizza().ToList());
            ser.SerilizerUser("BackUpUser.XML",repo.DisplayUsuario().ToList());

            Environment.Exit(0);
        }

    }
}

