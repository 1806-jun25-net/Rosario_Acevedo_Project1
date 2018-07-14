using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittleJohnsHut.DBAccess;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}