using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace LittleJohnsPizza.Library.Function
{
    public class Input
    {
        public void RegisterUser(string FN, string LN, string UN, int loc)
        {
            var User = new Users { FirstName = FN, LastName = LN, UserName = UN, LocationId = loc };
            using(var db = new LitteJohnsDBContext())
            {
                db.Update(User);
                db.SaveChanges();
            }
        }
        public void AddIventory(string NP, int Q, Locations loc)
        {
            var Inv = new Inventory { NameOfProduct = NP, Quantity = Q,  Location = loc };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(Inv);
                db.SaveChanges();
            }
        }
        public void AddLocation(string AL1, string AL2, string ZC)
        {
            var Local = new Locations { AdressLine1 = AL1, AdressLine2 = AL2, ZipCode = ZC  };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(Local);
                db.SaveChanges();
            }
        }
        public void Ordering(DateTime OD, int PC, Locations loc, Users users, decimal P)
        {
            var order = new Orders {OrderDate = OD, PizzaCount = PC, Price = P, User = users, Location = loc };
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(order);
                db.SaveChanges();
            }
        }
        public void MakeingPizzas(string NP, string crust, string s, Orders orders)
        {
            var Pie = new Pizza { NameofPizza =NP, Crust = crust, Sauce = s, Order = orders};
            using (var db = new LitteJohnsDBContext())
            {
                db.Update(Pie);
                db.SaveChanges();
            }
        }
    }
}
