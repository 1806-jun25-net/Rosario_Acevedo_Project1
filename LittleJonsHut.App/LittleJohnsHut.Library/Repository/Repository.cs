using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Model;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleJohnsHut.Library.Repository
{
    public class Repository
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly LittleJohnsHut.DBAccess.LitteJohnsDBContext _db;

        public Repository(LitteJohnsDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        /// <summary>
        /// his method finds the pizzas by ID. it searches the data base to see each any other pizza in the data base
        /// </summary>

        /// <param name="input"></param>
        /// <returns>a Pizza Object mapped to model class</returns>
        public Model.Pizza FindPizzaByID(int input)
        {
            DBAccess.Pizza piz = new DBAccess.Pizza();
            try
            {
                piz = _db.Pizza.FirstOrDefault(u => u.Id == input);
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "NullPointer Error");
                Console.WriteLine("Not found in the data base");
            }
            if (piz == null)
            {
                return null;
            }

            return Mapper.Map(piz);
        }
        /// <summary>
        /// Finds the pizza in the database using the name as a key it only gives back the first name it finds
        /// </summary>
        /// <param name="input"></param>
        /// <returns>a Pizza Object mapped to model class</returns>
        public Model.Pizza FindPizzaByName(string input)
        {
            DBAccess.Pizza piz = new DBAccess.Pizza();
            try
            {
                piz = _db.Pizza.FirstOrDefault(u => u.NameofPizza == input);
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e,"NullPointer Error");
                Console.WriteLine("Not found in the data base");
            }
            if (piz == null)
            {
                return null;
            }

            return Mapper.Map(piz);
        }
        /// <summary>
        ///  this class adds a user to the database 
        /// </summary>
        /// <param name="fn">First Name of the user</param>
        /// <param name="ln">Last Name of the User</param>
        /// <param name="un">User Name of the client</param>
        /// <param name="loc">the location of set client</param>
        public void RegisterUser(string fn, string ln,string un, string loc)
        {
           
           
            Locations Location = _db.Locations.FirstOrDefault(u =>u.AdressLine1  == loc );
            if (Location == null)
            {
                
                throw new ArgumentException("Locaiton was not found", nameof(loc));
            }
            var User = new Users
            {
               FirstName  = fn, 
               LastName = ln, 
               UserName = un, 
               LocationId = Location.Id

            };
            _db.Add(User);
            
        }
        /// <summary>
        /// this method finds the location utilizing the id
        /// </summary>
        /// <param name="ad1">the ID of the location </param>
        /// <returns>a location object mapped to a model location</returns>
        public Location FindLocationByID(int ad1)
        {
           
            var Loc = _db.Locations.FirstOrDefault(p => p.Id == ad1);
            return Mapper.Map(Loc);
         
            //return Mapper.Map(_db.Locations.Include(o => o.Id).AsNoTracking().First(o => o.Id == ad1));
        }
        /// <summary>
        /// Find's the Location using a string value 
        /// </summary>
        /// <param name="ad1">uses the addrress line 1 </param>
        /// <returns>returns a location object, this object is the result of the method</returns>
        public Location FindLocationByAdrress(string ad1)
        {
            var Loc = _db.Locations.FirstOrDefault(p => p.AdressLine1 == ad1);
            return Mapper.Map(Loc);
        }
        /// <summary>
        /// Displays the all location 
        /// </summary>
        /// <returns>returns a list of locaiton</returns>
        public IEnumerable<Location> DisplayLocation()
        {

          
            return Mapper.Map(_db.Locations.AsNoTracking()).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> DisplayOrderLocation()
        {
            List<Orders> order = _db.Orders.Include(o => o.Location).AsNoTracking().ToList();
            return Mapper.Map(order);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Pizza> DisplayPizza()
        {
            List<DBAccess.Pizza> pizza = _db.Pizza.AsNoTracking().ToList();
            return Mapper.Map(pizza);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public User FindUserByName(string input)
        {
            Users user = new Users();
            try
            {
                user = _db.Users.FirstOrDefault(u => u.UserName == input);
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Null Pointer Error");
                Console.WriteLine("Not found in the data base");
            }
            if (user == null)
            {
                return null; 
            }

            return Mapper.Map(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Order FindUserByOrderID(int input)
        {
            Orders order = new Orders();
            try
            {
                
                
                order = _db.Orders.FirstOrDefault(u => u.Id == input);
            }
            catch (ArgumentNullException e)
            {

                logger.Error(e, "Null Pointer Error");
                Console.WriteLine("Not found in the data base");
            }
            if (order == null)
            {
                return null;
            }

            return Mapper.Map(order);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> DisplayLatest()
        {
            List<Order> ord = DisplayOrder().OrderBy(o => o.OrderDate).ToList();

            return ord;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> DiplayEarliests()
        {
            List<Order> ord = DisplayOrder().OrderByDescending(o => o.OrderDate).ToList();

            return ord;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> DiplayMostExpencive()
        {
            List<Order> ord = DisplayOrder().OrderBy(o => o.Price).ToList();

            return ord;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> DiplayCheapest()
        {
            List<Order> ord = DisplayOrder().OrderByDescending(o => o.Price).ToList();

            return ord;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> DisplayOrder()
        {
            List<Orders> order = _db.Orders.AsNoTracking().ToList();
            return Mapper.Map(order);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.Inventory> DisplayInventory()
        {
            List<DBAccess.Inventory> Inv = _db.Inventory.AsNoTracking().ToList();
            return Mapper.Map(Inv);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.User> DisplayUsuario()
        {
            List<DBAccess.Users> Inv = _db.Users.AsNoTracking().ToList();
            return Mapper.Map(Inv);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> DisplayOrderUser()
        {
            List<Orders> order = _db.Orders.Include(o => o.User).AsNoTracking().ToList();
            return Mapper.Map(order);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="dateOfOreder"></param>
        /// <param name="pc"></param>
        /// <param name="loc"></param>
        /// <param name="un"></param>
        public void ordering(decimal cost, DateTime dateOfOreder, int pc, string loc, string un)
        {
            var local = _db.Locations.FirstOrDefault(l => l.AdressLine1 == loc);
            var UserName = _db.Users.FirstOrDefault(u => u.UserName == un);
            
            if (local == null)
            {
                Console.WriteLine( ("Location not found" + loc));
               
            }else if (UserName == null)
            {
                Console.WriteLine( ("User Not Found"+ un));
            }else if (pc < 0 || pc > 12  || cost > 500 || cost < 0)
            {
                Console.WriteLine(($"you cannot have, Pizzas Inputed: {pc} nor Cost: {cost}"));
            }
           
            var order = new Orders {
                OrderDate = dateOfOreder,
                PizzaCount = pc, 
                Price = cost, 
                LocationId = local.Id, 
                UserId = UserName.Id

            };
            _db.Add(order);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InvID"></param>
        /// <param name="PizID"></param>
       public void creatingPizza(int InvID, int PizID)
        {
            var pizza = _db.Pizza.FirstOrDefault(p => p.Id == PizID);
            var inv = _db.Inventory.FirstOrDefault(i => i.Id == InvID);
            if (pizza == null)
            {
                throw new ArgumentException("This pizza does not exist", nameof(InvID));
            }
            else if (inv == null)
            {
                throw new ArgumentException("User Not Found", nameof(PizID));
            }
            var P_I = new PizzaToopingIngrediant
            {
                InventoryId = inv.Id,
                PizzaId = pizza.Id
                
            };
            _db.Add(P_I);
            UpdatingInventroy(P_I.InventoryId);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LocationId"></param>
        /// <returns></returns>
        public List<Model.Inventory> findingInvetoryByLocationID(int LocationId)
        {
            string input = LocationId+"";
            List<Model.Inventory> inv = Mapper.Map((from a in _db.Inventory where Convert.ToString(a.LocationId).Contains(input) select a)).ToList();
            return inv;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       public IEnumerable<ProcessOrder> Recomeneded()
        {

            IEnumerable<ProcessOrder> Recom = _db.ProcessOrder.Include(P => P.Pizza).Include(u => u.Order).AsNoTracking();

            return Recom;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ad1"></param>
        /// <returns></returns>
        public ProcessOrder RecomendedUserOrder(int ad1)
        {
            var Loc = Recomeneded().FirstOrDefault(p => p.Order.User.Id == ad1);
            return Loc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<decimal, ProcessOrder>> RecomenededbyPrice()
        {
            var po = Recomeneded().GroupBy(p => p.Order.Price);
            return po;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizID"></param>
        /// <param name="OrderID"></param>
        public void AddPizzaToOrder(int pizID, int OrderID)
        {
            try
            {
                Orders findOrder = Mapper.Map(FindUserByOrderID(OrderID));
            }
            catch (Exception e)
            {

            }
            
                DBAccess.Pizza pizza = Mapper.Map(FindPizzaByID(pizID));
            ProcessOrder po = new ProcessOrder
            {
                OrderId = OrderID,
                PizzaId = pizID
            };
            _db.Add(po);
           

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Users> timeValidation()
        {
            var users = _db.Users.Include(u => u.Orders).AsNoTracking().ToList();

            return users;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public void UpdatingInventroy(int Id)
        {
            
            var inv = _db.Inventory.Find(Id);
            if (inv == null)
            {
                throw new ArgumentException($"No Such Inventroy left for this item {Id}");
            }else if (inv.Quantity <= 0)
            {
                throw new ArgumentException($"No Inventroy left for {inv.NameOfProduct}");
            }
            inv.Quantity = inv.Quantity-1;
           _db.Update(inv);
          
        }
        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Do"></param>
        /// <returns></returns>
        public Orders FindDO( DateTime Do)
        {
            var DO = _db.Orders.FirstOrDefault(u => u.OrderDate == Do);
            return DO;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public User FindUserByID(int iD)
        {
            Users user = new Users();
            try
            {
                user = _db.Users.FirstOrDefault(u => u.Id == iD);
            }
            catch (ArgumentNullException e)
            {

                logger.Error(e, "Null Pointer Error");
                Console.WriteLine("Not found in the data base");
            }
            if (user == null)
            {
                return null;
            }

            return Mapper.Map(user);
        }
    }
}
