using System;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsPizza.Library.Function
{
    public class Update
    {
        public void UpdateUser(int ID, string FN, string LN, string UN, Locations loc)
        {
            var User = new Users {Id = ID, FirstName = FN, LastName = LN, UserName = UN, Location = loc };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(User);
                db.SaveChanges();
            }
        }
        public void AddIventory(int ID, string NP, int Q, Locations loc)
        {
            var Inv = new Inventory {Id = ID, NameOfProduct = NP, Quantity = Q, Location = loc };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(Inv);
                db.SaveChanges();
            }
        }
        public void AddLocation(int ID , string AL1, string AL2, string ZC)
        {
            var Local = new Locations {Id = ID, AdressLine1 = AL1, AdressLine2 = AL2, ZipCode = ZC };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(Local);
                db.SaveChanges();
            }
        }
        public void Ordering(int ID, DateTime OD, int PC, Locations loc, Users users, decimal P)
        {
            var order = new Orders {Id = ID, OrderDate = OD, PizzaCount = PC, Price = P, User = users, Location = loc };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(order);
                db.SaveChanges();
            }
        }
        public void MakeingPizzas(int ID, string NP, string crust, string s, Orders orders)
        {
            var Pie = new Pizza {Id = ID, NameofPizza = NP, Crust = crust, Sauce = s, Order = orders };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(Pie);
                db.SaveChanges();
            }
        }
    }
}
