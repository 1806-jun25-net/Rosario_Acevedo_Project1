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
        public Location FindLocationByID(int ad1)
        {
            var Loc = _db.Locations.FirstOrDefault(p => p.Id == ad1);
            return Mapper.Map(Loc);
        }
        public Location FindLocationByAdrress(string ad1)
        {
            var Loc = _db.Locations.FirstOrDefault(p => p.AdressLine1 == ad1);
            return Mapper.Map(Loc);
        }
        public IEnumerable<Location> DisplayLocation()
        {

          
            return Mapper.Map(_db.Locations.AsNoTracking()).ToList();
        }
        public IEnumerable<Order> DisplayOrderLocation()
        {
            List<Orders> order = _db.Orders.Include(o => o.Location).AsNoTracking().ToList();
            return Mapper.Map(order);
        }

        public IEnumerable<Model.Pizza> DisplayPizza()
        {
            List<DBAccess.Pizza> pizza = _db.Pizza.AsNoTracking().ToList();
            return Mapper.Map(pizza);
        }
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
        public IEnumerable<Order> DiplayEarliest()
        {
            List<Order> ord = DisplayOrder().OrderBy(o => o.OrderDate).ToList();

            return ord;
        }
        public IEnumerable<Order> DiplayLatest()
        {
            List<Order> ord = DisplayOrder().OrderByDescending(o => o.OrderDate).ToList();

            return ord;
        }
        public IEnumerable<Order> DiplayMostExpencive()
        {
            List<Order> ord = DisplayOrder().OrderBy(o => o.Price).ToList();

            return ord;
        }
        public IEnumerable<Order> DiplayCheapest()
        {
            List<Order> ord = DisplayOrder().OrderByDescending(o => o.Price).ToList();

            return ord;
        }
        public IEnumerable<Order> DisplayOrder()
        {
            List<Orders> order = _db.Orders.AsNoTracking().ToList();
            return Mapper.Map(order);
        }
        public IEnumerable<Model.Inventory> DisplayInventory()
        {
            List<DBAccess.Inventory> Inv = _db.Inventory.AsNoTracking().ToList();
            return Mapper.Map(Inv);
        }
        public IEnumerable<Model.User> DisplayUsuario()
        {
            List<DBAccess.Users> Inv = _db.Users.AsNoTracking().ToList();
            return Mapper.Map(Inv);
        }
        public IEnumerable<Order> DisplayOrderUser()
        {
            List<Orders> order = _db.Orders.Include(o => o.User).AsNoTracking().ToList();
            return Mapper.Map(order);
        }
        public void ordering(decimal cost, DateTime dateOfOreder, int pc, string loc, string un)
        {
            var local = _db.Locations.FirstOrDefault(l => l.AdressLine1 == loc);
            var UserName = _db.Users.FirstOrDefault(u => u.UserName == un);
            
            if (local == null)
            {
                throw new ArgumentException("Location not found", loc);
               
            }else if (UserName == null)
            {
                throw new ArgumentException("User Not Found", un);
            }else if (pc < 0 || pc > 12  || cost > 500 || cost < 0)
            {
                throw new ArgumentException($"you cannot have, Pizzas Inputed: {pc} nor Cost: {cost}");
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
        public List<Model.Inventory> findingInvetoryByLocationID(int LocationId)
        {
            string input = LocationId+"";
            List<Model.Inventory> inv = Mapper.Map((from a in _db.Inventory where Convert.ToString(a.LocationId).Contains(input) select a)).ToList();
            return inv;

        }
       
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
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
