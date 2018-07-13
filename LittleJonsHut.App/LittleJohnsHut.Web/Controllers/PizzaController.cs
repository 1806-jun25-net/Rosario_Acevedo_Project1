using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LittleJohnsHut.Web.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {

            return View();
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}