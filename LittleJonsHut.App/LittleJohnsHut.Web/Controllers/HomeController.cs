using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LittleJohnsHut.Web.Models;
using LittleJohnsHut.Library.Repository;
using LittleJohnsHut.Library.Model;
using LittleJohnsHut.DBAccess;
using Microsoft.AspNetCore.Routing;

namespace LittleJohnsHut.Web.Controllers
{
    public class HomeController : Controller
    {
        public Repository Repo { get; }
        
        public HomeController(Repository repo)
        {
            Repo = repo;
        }
       public WebUser webUser { get; set; }
        public IActionResult Index([FromQuery] string name)
        {
            if (name == null)
            {
                return View();
            }
            else
            {
                ViewBag.view = Repo.FindUserByName(name);
                Users wbUser = Repo.FindUserByName(name);
               if ( wbUser == null) {


                }else
                {
                    
                        var Session = new WebUser
                        {
                            Id = wbUser.Id,
                            FirstName = wbUser.FirstName,
                            LastName = wbUser.LastName,
                          
                        
                       
                    };
                    webUser = Session;
                    return RedirectToAction("User", new RouteValueDictionary(
                            new { action = "Index",  UserId = Session.Id }
                        
                        ));
                    
                }
              
            }
          
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
