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
            _db.Add(User);

        }
        public IEnumerable<Locations> DisplayLocation()
        {

            List<Locations> Location =  _db.Locations.AsNoTracking().ToList();
            return Location;
        }
        public IEnumerable<Orders> DisplayOrderLocation()
        {
            List<Orders> order = _db.Orders.Include(o => o.Location).AsNoTracking().ToList();
            return order;
        }
        public IEnumerable<Orders> DisplayOrderUser()
        {
            List<Orders> order = _db.Orders.Include(o => o.User).AsNoTracking().ToList();
            return order;
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
                throw new ArgumentException("Location not found", un);
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

       public void creatingPizza(int OrderID, string NameofPizza, string Crust, string Sauce, string sizeOfPizza, string NameOfTopping)
        {

        }
    }
}
