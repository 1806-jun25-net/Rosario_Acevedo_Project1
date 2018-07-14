using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittleJohnsHut.Library.Repository;
using LittleJohnsHut.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LittleJohnsHut.Web.Controllers
{
    public class PizzaController : Controller
    {

        public Repository Repo { get; }

        public PizzaController(Repository repo)
        {
            Repo = repo;
        }
        // GET: Pizza
        [Route ("Pizza")]
        public ActionResult Index()
        {
            var libPizza = Repo.DisplayPizza();
            var webPizza = libPizza.Select(x => new WebPizza
            {
                NameofPizza = x.NameofPizza,
                Id = x.Id, 
                Crust = x.Crust, 
                NameOfTooping =x.NameOfTooping,
                SizeOfPizza  = x.SizeOfPizza
            });
            return View(webPizza);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}