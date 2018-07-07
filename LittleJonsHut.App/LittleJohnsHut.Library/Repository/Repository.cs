using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleJohnsHut.Library.Repository
{
    public class Repository
    {
        private readonly LittleJohnsHut.DBAccess.LitteJohnsDBContext _db;

        public Repository(LitteJohnsDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void RegisterUser(string fn, string ln,string un, Locations loc)
        {
           
           
            var Location = _db.Users.FirstOrDefault(u =>u.Location.AdressLine1  == loc.AdressLine1 );
            if (Location == null)
            {
                throw new ArgumentException("Locaiton was not found", nameof(loc));
            }
            var User = new Users
            {
               FirstName  = fn, 
               LastName = ln, 
               UserName = un, 
               Location = loc
              
            };
            _db.Add(Mapper.Map(User));

        }
        public IEnumerable<Location> DisplayLocation()
        {

           // List<Locations> Location =  _db.Locations.AsNoTracking().ToList();
            return Mapper.Map(_db.Locations.AsNoTracking()).ToList();
        }
        public IEnumerable<Order> DisplayOrderLocation()
        {
            List<Orders> order = _db.Orders.Include(o => o.Location).AsNoTracking().ToList();
            return Mapper.Map(order);
        }
        public IEnumerable<User> FindUserByName(string input)
        {
            var user = _db.Users.FirstOrDefault(u => u.FirstName == input);
            if (user == null) { throw new ArgumentException("Wrong input, this person does not exist in the database"); }

            yield return Mapper.Map(user);
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
                Location = local, 
                User = UserName

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
                PizzaId = pizza.Id,
                Pizza = pizza,
                Inventory = inv
            };
            _db.Add(P_I);
            UpdatingInventroy(P_I.InventoryId);
            
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
            var invetory = new Model.Inventory{
                Id = Id, 
                Quantity = inv.Quantity - 1, 
                NameOfProduct = inv.NameOfProduct,
                Location = Mapper.Map(inv.Location), 
                
            };
          
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
