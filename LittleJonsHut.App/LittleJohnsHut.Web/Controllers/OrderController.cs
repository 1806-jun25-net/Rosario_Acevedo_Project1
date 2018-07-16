using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittleJohnsHut.DBAccess;
using LittleJohnsHut.Library.BusinessLogic;
using LittleJohnsHut.Library.Model;
using LittleJohnsHut.Library.Repository;
using LittleJohnsHut.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LittleJohnsHut.Web.Controllers
{
    public class OrderController : Controller
    {
        public Repository Repo { get; }

        public OrderController(Repository repo)
        {
            Repo = repo;
        }
        // GET: Order
        [Route("Ordering")]
        public ActionResult Index([FromQuery]int btnPress)
        {    
            ViewBag.Debug = btnPress;
            var libOrder = Repo.DisplayOrder();
            var wbOrder = libOrder.Select(x => new WebOrder
            {
                Id = x.Id,
                OrderDate = x.OrderDate,
                PizzaCount = x.PizzaCount,
                Price = x.Price,
                locationId = x.locationId,
                UserId =x.UserId
            });
            if (btnPress == 1)
            {
                wbOrder = wbOrder.OrderBy(x => x.OrderDate);
            }
            else if (btnPress == 2)
            {
                wbOrder = wbOrder.OrderByDescending(x => x.OrderDate);
            }
            else if (btnPress == 3)
            {
                wbOrder = wbOrder.OrderBy(x => x.Price);
            }
            else if (btnPress == 4)
            {
                wbOrder = wbOrder.OrderByDescending(x => x.Price);
            }
            return View(wbOrder);
           
        }
      
        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        //[Route("User/Order/{id?}")]
        public ActionResult Order([FromQuery] int locationId, [FromQuery] int UserId)
        {
           // Validation v = new  Validation();
           // var session = Repo.FindUserByID(id);
           // ViewData["session"] = session.FirstName;

            return View("Order");
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken] 
       
        public ActionResult Order(IFormCollection collection, string locationId, int UserId, int PizzaPep, int PizzaMeatLover, int PizzaVeggie, int PizzaSuprema)
        {
            Mapper map = new Mapper();
            Validation v = new Validation();
            IEnumerable<Order> t = Repo.DisplayOrder();
            int PizzaCount = PizzaPep + PizzaMeatLover + PizzaSuprema + PizzaVeggie;
            var session = Repo.FindUserByID(Convert.ToInt32(UserId));
            var loc = Repo.FindLocationByID(Convert.ToInt32(locationId));
            try
            {
                foreach (var item in t)
                {
                    var diff = DateTime.Now - item.OrderDate;

                    if ((diff < TimeSpan.FromHours(2)) && (Convert.ToInt32(UserId) == item.UserId) && (Convert.ToInt32(locationId) == item.locationId))
                    {
                        ViewBag.Error = "Please wait until your pizza is done waiting time: " + diff.Value.TotalHours;
                        
                        return View();
                    }
                }
                  

                
                
               
                if ((PizzaCount < 12 && PizzaCount > 0) ) {
                    
                    decimal cost = v.PriceValidation() * PizzaCount;
                    DateTime DO = DateTime.Now;
                    Repo.ordering(cost, DO, PizzaCount, loc.AdressLine1, session.UserName);
                    Repo.Save();
                    Library.Model.Pizza pi = new Library.Model.Pizza();
                    List<Library.Model.Pizza> pi2 = new List<Library.Model.Pizza>();
                    for (int i = 0; i < PizzaCount; i++)
                    {

                        if (PizzaPep > i){
                            pi = Pizzamaker(Convert.ToInt32(locationId));
                            pi2.Add(pi);
                        }
                        if (PizzaMeatLover > i)
                        {
                            pi = PizzamakerMeatLover(Convert.ToInt32(locationId));
                            pi2.Add(pi);
                        }
                        if (PizzaSuprema > i)
                        {
                            pi = PizzamakerPizzaSuprema(Convert.ToInt32(locationId));
                            pi2.Add(pi);
                        }
                        if (PizzaVeggie > i)
                        {
                           pi= PizzamakerVeggie(Convert.ToInt32(locationId));
                            pi2.Add(pi);
                        }
                        
                    }
                    var thisOrder = Repo.FindDO(DO);
                    foreach (var item in pi2)
                    {
                        Repo.AddPizzaToOrder(item.Id, thisOrder.Id );
                    }
                    Repo.Save();
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    ViewBag.Error = "You cannot order more than 12 pizza please try again your input is: "+PizzaCount;
                    return View();
                }
            }
            catch
            {
                ViewBag.Error = "it shall not pass";
                return View();
            }
        }
        
        private Library.Model.Pizza PizzamakerVeggie(int v)
        {
            var inv = Repo.findingInvetoryByLocationID(v);
            Validation mm = new Validation();
            var piz = Repo.FindPizzaByID(6);
            var MaipulatingInventoryChesse = mm.FindInventoryByType("Cheese", inv);
            var MaipulatingInventoryDough = mm.FindInventoryByType("Dough", inv);
            var MaipulatingInventorySauce = mm.FindInventoryByType("Sauce", inv);
            var MaipulatingInventoryVeggie2 = mm.FindInventoryByType("Veggie", inv);
            Repo.creatingPizza(MaipulatingInventoryVeggie2.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryChesse.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryDough.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventorySauce.Id, piz.Id);
            return piz;
        }

        private Library.Model.Pizza PizzamakerPizzaSuprema(int v)
        {
            var inv = Repo.findingInvetoryByLocationID(v);
            Validation mm = new Validation();
            var piz = Repo.FindPizzaByID(3);
            var MaipulatingInventoryChesse = mm.FindInventoryByType("Cheese", inv);
            var MaipulatingInventoryDough = mm.FindInventoryByType("Dough", inv);
            var MaipulatingInventorySauce = mm.FindInventoryByType("Sauce", inv);
            var MaipulatingInventoryVeggie2 = mm.FindInventoryByType("Veggie", inv);
            var MaipulatingInventoryVeggie5 = mm.FindInventoryByType("Bacon", inv);
            var MaipulatingInventoryVeggie3 = mm.FindInventoryByType("Ham", inv);
            var MaipulatingInventoryVeggie4 = mm.FindInventoryByType("Peperoni", inv);
            Repo.creatingPizza(MaipulatingInventoryVeggie2.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryChesse.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryDough.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventorySauce.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryVeggie5.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryVeggie3.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryVeggie4.Id, piz.Id);
            return piz;
        }

        private Library.Model.Pizza PizzamakerMeatLover(int v)
        {
            var inv = Repo.findingInvetoryByLocationID(v);
            Validation mm = new Validation();
            var piz = Repo.FindPizzaByID(5);
            var MaipulatingInventoryChesse = mm.FindInventoryByType("Cheese", inv);
            var MaipulatingInventoryDough = mm.FindInventoryByType("Dough", inv);
            var MaipulatingInventorySauce = mm.FindInventoryByType("Sauce", inv);
            var MaipulatingInventoryVeggie2 = mm.FindInventoryByType("Bacon", inv);
            var MaipulatingInventoryVeggie3 = mm.FindInventoryByType("Ham", inv);
            var MaipulatingInventoryVeggie4 = mm.FindInventoryByType("Peperoni", inv);
            Repo.creatingPizza(MaipulatingInventoryVeggie2.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryChesse.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryDough.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventorySauce.Id, piz.Id);
        
            Repo.creatingPizza(MaipulatingInventoryVeggie3.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryVeggie4.Id, piz.Id);
            return piz;
        }

        private Library.Model.Pizza Pizzamaker(int v)
        {

            var inv = Repo.findingInvetoryByLocationID(v);
            Validation mm = new Validation();
            var piz = Repo.FindPizzaByID(2);
            var MaipulatingInventoryChesse = mm.FindInventoryByType("Cheese", inv);
            var MaipulatingInventoryDough = mm.FindInventoryByType("Dough", inv);
            var MaipulatingInventorySauce = mm.FindInventoryByType("Sauce", inv);
            var MaipulatingInventoryVeggie2 = mm.FindInventoryByType("Peperoni", inv);
            Repo.creatingPizza(MaipulatingInventoryVeggie2.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryChesse.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventoryDough.Id, piz.Id);
            Repo.creatingPizza(MaipulatingInventorySauce.Id, piz.Id);
            return piz;
        }
    }
}