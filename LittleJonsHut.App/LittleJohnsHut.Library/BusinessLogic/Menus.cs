//using LittleJohnsHut.DBAccess;
//using LittleJohnsHut.Library.BusinessLogic;
//using LittleJohnsHut.Library.Model;
//using LittleJohnsHut.Library.Repository;
//using LittleJohnsHut.Library.XML;
//using LittleJohnsPizza.Library.XML;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using NLog;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace LittleJohnsHut.Library
//{
//    /// <summary>
//    /// This class is created to take all the users input
//    /// also contins various clases that calcualte and search in the data base
//    /// </summary>
//    public class Menus
//    {
//        /// <summary>
//        /// Get the session of the user 
//        /// </summary>
//        public User Session { get; set; }
//        /// <summary>
//        /// This class is use to Register the User  and also checks if the user has a unique Username 
//        /// </summary>
//        public void Register()
//        {
//            #region database
//            var builder = new ConfigurationBuilder()
//                           .SetBasePath(Directory.GetCurrentDirectory())
//                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = builder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
//            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
//            #endregion


//            Console.WriteLine("Please enter your First name");
//            string fn = Console.ReadLine();
//            Console.WriteLine("Please enter your Last Name");
//            string ln = Console.ReadLine();
//            Console.WriteLine("Please enter a Unique UserName");
//            string un = Console.ReadLine();

//            User Checking = repo.FindUserByName(un);
//            Validation v = new Validation();
//            if (v.UniqueUser(Checking))
//            {
//                StartingMenu();
//            }
//            Console.WriteLine("Please enter a Location, here is a list of our locations");
//            List<Location> loc = repo.DisplayLocation().ToList();
//            int c = 0;
//            foreach (var item in loc)
//            {
//                c++;
//                Console.WriteLine($"Location {c}:{item.AdressLine1}");
//            }
//            string address = Console.ReadLine();

//            if (v.LocationInDataBase(loc, address))
//            {
//                repo.RegisterUser(fn, ln, un, address);
//                repo.Save();
//                session(repo.FindUserByName(un));
//                Session = repo.FindUserByName(un);
//                ContinuesMenu();
//            }


//            Console.WriteLine("wrong input please try again");
//            StartingMenu();




//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void RetruningClient()
//        {
//            #region database
//            var builder = new ConfigurationBuilder()
//                            .SetBasePath(Directory.GetCurrentDirectory())
//                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = builder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
//            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
//            #endregion 

//            Console.WriteLine("Write your User Name: ");
//            string input = Console.ReadLine();
//            User users = repo.FindUserByName(input);
//            if (users == null)
//            {
//                Console.WriteLine("try Agian ");
//                StartingMenu();
//            }

//            session(users);
//            Session = repo.FindUserByName(users.UserName);
//            ContinuesMenu();

//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="user"></param>
//        public void session(User user)
//        {
//            Serilize ser = new Serilize();
//            ser.SerilizerSession("RemeberSession.XML", user);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void StartingMenu()
//        {
//            Console.WriteLine("Are you a retunring customer? press Y to Yes press N to register, press X to Exit, Press F for fast Log in");
//            string input = Console.ReadLine();
//            if (input.ToUpper() == "Y")
//            {
//                RetruningClient();
//            }
//            else if (input.ToUpper() == "N")
//            {
//                Register();
//            }
//            else if (input.ToUpper() == "X")
//            {
//                Exit();
//            }
//            else if (input.ToUpper() == "F")
//            {
//                FastEntry();
//                ContinuesMenu();
//            }
//            else
//            {
//                Console.WriteLine("WrongInput");
//                StartingMenu();
//            }

//        }
//        public void FastEntry()
//        {
//            DeSerilize ser = new DeSerilize();
//            Session = ser.DesSession("RemeberSession.XML").Result;
//        }
//        public void ContinuesMenu()
//        {
//            Console.WriteLine($"Welcome :{Session.FirstName} {Session.LastName}");
//            Console.WriteLine($"Plese Choose a option press the number on the left of the option \n" +
//                $"1. Order your pizza\n" +
//                $"2. Sorting and adminstrating\n " +
//                $"3. Searching by a catagory\n" +
//                $"4. Exit your application \n" +
//                $"5. sign out");
//            string input = Console.ReadLine();

//            switch (input)
//            {
//                case "1":
//                    OrderMenu();
//                    break;
//                case "2":
//                    SortingMenu();
//                    break;
//                case "3":
//                    SearchingMenu();
//                    break;
//                case "4":
//                    Exit();
//                    break;
//                case "5":
//                    StartingMenu();
//                    break;
//                default:
//                    Console.WriteLine("wrong input try agian");
//                    ContinuesMenu();
//                    break;
//            }

//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void SearchingMenu()
//        {
//            #region database
//            var builder = new ConfigurationBuilder()
//                           .SetBasePath(Directory.GetCurrentDirectory())
//                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = builder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
//            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
//            #endregion

//            Console.WriteLine("Enter what you want to search for:\n" +
//                "1. Search for User\n" +
//                "2. Search for Order\n " +
//                "3. Go Back\n" +
//                "4. Exit");
//            string input = Console.ReadLine();
//            switch (input)
//            {
//                case "1":
//                    Console.WriteLine("Please Enter your User Name");
//                    input = Console.ReadLine();
//                    Users user = repo.FindUserByName(input);
//                    if (user == null)
//                    {
//                        Console.WriteLine("Wrong input try again");
//                        SearchingMenu();
//                    }
//                    else
//                    {
//                        var loc = repo.FindLocationByID(user.locationID);
//                        Console.WriteLine($"First Name: {user.FirstName} \n " +
//                            $"Last Name: {user.LastName}\n " +
//                            $"User Name: {user.UserName}\n " +
//                            $"Address: {loc.AdressLine1}");
//                        ContinuesMenu();
//                    }
//                    break;
//                case "2":
//                    Console.WriteLine("Please Enter your Order ID");
//                    input = Console.ReadLine();
//                    int i = 0;
//                    try
//                    {
//                        i = Convert.ToInt32(input);
//                    }
//                    catch (Exception e) { Console.WriteLine("Wrong input try again"); ContinuesMenu(); }

//                    Order o = repo.FindUserByOrderID(i);
//                    User u = repo.FindUserByID(o.UserId);
//                    Location l = repo.FindLocationByID(o.locationId);
//                    if (o == null)
//                    {
//                        Console.WriteLine("Wrong input try again");
//                        SearchingMenu();
//                    }
//                    else
//                    {
//                        Console.WriteLine($"ID: {o.Id} \n " +
//                            $"Date : {o.OrderDate}\n " +
//                            $"Pizzas: {o.PizzaCount}\n " +
//                            $"in: {l.AdressLine1} \n" +
//                            $"to: {u.FirstName} {u.LastName}");

//                        ContinuesMenu();
//                    }
//                    break;
//                case "3":
//                    ContinuesMenu();
//                    break;
//                case "4":
//                    Exit();
//                    break;
//                default:
//                    SearchingMenu();
//                    break;

//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void SortingMenu()
//        {
//            #region database
//            var builder = new ConfigurationBuilder()
//                      .SetBasePath(Directory.GetCurrentDirectory())
//                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = builder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
//            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
//            #endregion

//            Console.WriteLine("do you want to use your location? press Y for yes and N for no ");
//            Console.WriteLine("Choose the sort you want to implement \n" +
//                "1. Sort by order history by latest\n" +
//                "2. Sort by order history by earliest\n" +
//                "3. Sort by order history by most expensive\n" +
//                "4. Sort by order history by cheapest \n" +
//                "5. return to main menu \n" +
//                "6. exit the aplication");

//            string inpt = Console.ReadLine();
//            var i = new List<Order>();
//            switch (inpt)
//            {
//                case "1":
//                    i = repo.DisplayLatest().ToList();
//                    break;
//                case "2":
//                    i = repo.DiplayEarliests().ToList();
//                    break;
//                case "3":
//                    i = repo.DiplayCheapest().ToList();
//                    break;
//                case "4":
//                    i = repo.DiplayMostExpencive().ToList();
//                    break;
//                case "5":
//                    ContinuesMenu();
//                    break;
//                case "6":
//                    Exit();
//                    break;
//                default:
//                    SortingMenu();
//                    break;
//            }
//            foreach (var item in i)
//            {
//                Console.WriteLine($"Pizza in order: {item.PizzaCount}\n" +
//                    $"Price: {item.Price}\n" +
//                    $"Order Date: {item.OrderDate}");
//            }
//            ContinuesMenu();
//        }

//        decimal cost { get; set; }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void OrderMenu()
//        {

//            #region database
//            var builder = new ConfigurationBuilder()
//                         .SetBasePath(Directory.GetCurrentDirectory())
//                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = builder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
//            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
//            #endregion
//            Validation v = new Validation();
//            cost = v.PriceValidation();
//            var CurrentUser = new Users();
//            var UserOrders = repo.timeValidation();

//            foreach (var item in UserOrders)
//            {
//                if (item.Id == Session.Id)
//                {
//                    CurrentUser = item;
//                }
//            }

//            if (v.timeValidation(CurrentUser.Orders.ToList()))
//            {
//                Console.WriteLine($"You Already order a pizza wait until we finish preparing the pizza, waiting time {v.diff.Value}");
//                ContinuesMenu();
//            }


//            Console.WriteLine("do you want to use your location? press Y for yes and N for no ");
//            string input = Console.ReadLine();
//            var loc = new Location();
//            if (input.ToUpper() == "Y")
//            {

//                loc = repo.FindLocationByID(Session.locationID);

//            }
//            else if (input.ToUpper() == "N")
//            {
//                Console.WriteLine("Please enter a Location, here is a list of our locations");
//                List<Location> locs = repo.DisplayLocation().ToList();
//                int c = 0;
//                foreach (var item in locs)
//                {
//                    c++;
//                    Console.WriteLine($"Location {c}:{item.AdressLine1}");
//                }
//                string address = Console.ReadLine();
//                loc = repo.FindLocationByAdrress(address);
//                if (loc == null)
//                {
//                    Console.WriteLine("Wrong input please try agian ");
//                    OrderMenu();
//                }
//            }
//            else
//            {
//                OrderMenu();
//            }


//            Console.WriteLine("Please enter the amount of pizza you want");
//            int p = 0;
//            var PC = Console.ReadLine();
//            try
//            {
//                p = Convert.ToInt32(PC);
//            }
//            catch (Exception e)
//            {
//                ContinuesMenu();
//            }
//            InvLocation = loc;
//            cost = cost * p;
//            if (cost < 0 || cost > 500)
//            {
//                ContinuesMenu();

//            }
//            if (p < 0 || p > 12)
//            {
//                Console.WriteLine($"you cannot have more than 12 nor less than 0 your input is {p}");
//                ContinuesMenu();
//            }
//            DateTime DO = DateTime.Now;
//            Model.Pizza pi = new Model.Pizza();
//            List<Model.Pizza> pi2 = new List<Model.Pizza>();
//            for (int i = 0; i < p; i++)
//            {

//                pi = PizzaMaker();

//                pi2.Add(pi);
//            }
//            if (cost < 0 || cost > 500)
//            {
//                Console.WriteLine($"Your cost is :{cost} please try agian with less pizzas");
//                ContinuesMenu();
//            }
//            repo.ordering(cost, DO, p, loc.AdressLine1, Session.UserName);
//            repo.Save();
//            var thisOrder = repo.FindDO(DO);

//            foreach (var item in pi2)
//            {
//                repo.AddPizzaToOrder(item.Id, thisOrder.Id);
//            }
//            repo.Save();
//            Console.WriteLine("your Order is the following: ID " + thisOrder.Id + "\n" + thisOrder.OrderDate + "\n" +
//                "" + thisOrder.PizzaCount + "\n" +
//                "" + thisOrder.Price + "\n");
//            ContinuesMenu();
//        }
//        private Location InvLocation { get; set; }
//        private static Logger logger = LogManager.GetCurrentClassLogger();
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public Model.Pizza PizzaMaker()
//        {

//            #region databse
//            var builder = new ConfigurationBuilder()
//                        .SetBasePath(Directory.GetCurrentDirectory())
//                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = builder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
//            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
//            #endregion
//            Console.WriteLine("Please choose your pizza from our selection"
//                             );


//            var pizza = repo.DisplayPizza();
//            foreach (var item in pizza)
//            {
//                Console.WriteLine(item.NameofPizza);
//            }
//            string input = Console.ReadLine();
//            var piz = new Model.Pizza();
//            try
//            {
//                piz = repo.FindPizzaByName(input);
//                var test = piz.Id;
//            }
//            catch (Exception e)
//            {

//                logger.Error(e, "File not found");
//                Console.WriteLine("The pizza you inserted does not exist please try again");
//                ContinuesMenu();
//            }
//            var InvetoryOfLocation = repo.findingInvetoryByLocationID(InvLocation.Id);



//            var mm = new Validation();

//            var MaipulatingInventoryChesse = mm.FindInventoryByType("Cheese", InvetoryOfLocation);
//            var MaipulatingInventoryDough = mm.FindInventoryByType("Dough", InvetoryOfLocation);
//            var MaipulatingInventorySauce = mm.FindInventoryByType("Sauce", InvetoryOfLocation);

//            repo.creatingPizza(MaipulatingInventoryChesse.Id, piz.Id);
//            repo.creatingPizza(MaipulatingInventoryDough.Id, piz.Id);
//            repo.creatingPizza(MaipulatingInventorySauce.Id, piz.Id);

//            switch (input)
//            {
//                case "Pizza Peperoni":
//                    var MaipulatingInventoryPeperoni = mm.FindInventoryByType("Peperoni", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryPeperoni.Id, piz.Id);
//                    cost = cost + Convert.ToDecimal(0.50);

//                    break;

//                case "Pizza Suprema":
//                    var MaipulatingInventoryBacon3 = mm.FindInventoryByType("Bacon", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryBacon3.Id, piz.Id);
//                    var MaipulatingInventoryHam3 = mm.FindInventoryByType("Ham", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryHam3.Id, piz.Id);
//                    var MaipulatingInventoryVeggie3 = mm.FindInventoryByType("Veggie", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryVeggie3.Id, piz.Id);
//                    var MaipulatingInventoryPeperoni2 = mm.FindInventoryByType("Peperoni", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryPeperoni2.Id, piz.Id);
//                    cost = cost + Convert.ToDecimal(1.50);
//                    break;


//                case "Pizza Mashroom":
//                    var MaipulatingInventoryVeggie = mm.FindInventoryByType("Veggie", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryVeggie.Id, piz.Id);
//                    cost = cost + Convert.ToDecimal(.50);

//                    break;
//                case "Pizza MeatLover":
//                    var MaipulatingInventoryBacon2 = mm.FindInventoryByType("Bacon", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryBacon2.Id, piz.Id);
//                    var MaipulatingInventoryHam2 = mm.FindInventoryByType("Ham", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryHam2.Id, piz.Id);
//                    cost = cost + Convert.ToDecimal(1.00);

//                    break;
//                case "Pizza veggi":
//                    var MaipulatingInventoryVeggie2 = mm.FindInventoryByType("Veggie", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryVeggie2.Id, piz.Id);
//                    cost = cost + Convert.ToDecimal(0.50);
//                    break;
//                case "Pizza Bacon":
//                    var MaipulatingInventoryBacon = mm.FindInventoryByType("Bacon", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryBacon.Id, piz.Id);
//                    cost = cost + Convert.ToDecimal(0.50);
//                    break;
//                case "Pizza Ham":
//                    var MaipulatingInventoryHam = mm.FindInventoryByType("Ham", InvetoryOfLocation);
//                    repo.creatingPizza(MaipulatingInventoryHam.Id, piz.Id);
//                    cost = cost + Convert.ToDecimal(0.50);
//                    break;
//            }
//            repo.Save();
//            return piz;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        public void Exit()
//        {
//            #region database
//            var builder = new ConfigurationBuilder()
//                         .SetBasePath(Directory.GetCurrentDirectory())
//                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = builder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<LitteJohnsDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBaseConnection"));
//            var repo = new Repository.Repository(new LitteJohnsDBContext(optionsBuilder.Options));
//            #endregion
//            Serilize ser = new Serilize();
//            #region Serilizer 
//            ser.SerilizeInventory("BackupInventory.XML", repo.DisplayInventory().ToList());
//            ser.SerilizerLocation("BackUpLocations.XML", repo.DisplayLocation().ToList());
//            ser.SerilizerOrder("BackUpOrder.XML", repo.DisplayOrder().ToList());
//            ser.SerilizerPizza("BackUpPizza.XML", repo.DisplayPizza().ToList());
//            ser.SerilizerUser("BackUpUser.XML", repo.DisplayUsuario().ToList());
//            #endregion
//            Environment.Exit(0);
//        }

//    }
//}

