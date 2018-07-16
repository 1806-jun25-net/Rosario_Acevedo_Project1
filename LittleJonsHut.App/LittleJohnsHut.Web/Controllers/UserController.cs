using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LittleJohnsHut.Library.Repository;
using LittleJohnsHut.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LittleJohnsHut.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User 
        public Repository Repo { get; }

        public UserController(Repository repo)
        {
            Repo = repo;
        }
        [Route ("Home/User")]
        public ActionResult Index([FromQuery]int UserId, [FromQuery]int OrderId)
        {

           // HomeController s = new HomeController(Repo);
            ViewBag.Id = UserId;
            var session = Repo.FindUserByID(UserId);

            if (session != null)
            {
                List<WebUser> wUser = new List<WebUser>();
                wUser.Add( new WebUser {
                        FirstName = session.FirstName, 
                        LastName = session .LastName, 
                        Id = session.Id, 
                        UserName = session.UserName,
                        locationid = session.locationID
                        
                });
                return View(wUser);
            }
            var libUser = Repo.DisplayUsuario();
            var wbUser = libUser.Select(x => new WebUser
            {
                FirstName = x.FirstName, 
                LastName =x.LastName,
                Id = x.Id, 
                UserName =x.UserName
            });
            
            return View(wbUser);
        }

     

        // GET: User/Create
      
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WebUser collection, string Loc)
        {
            if(Loc == "Reston" || Loc == "SanJuan" || Loc == "Tampa" || Loc == "Honolulu" || Loc == "Los Angeles" || Loc == "Kansas")
            {

                try
                {


                    var loc = Repo.FindLocationByAdrress(Loc);

                    Repo.RegisterUser(collection.FirstName, collection.LastName, collection.UserName, loc.Id);
                    Repo.Save();
                    var session = Repo.FindUserByName(collection.UserName);
                    return RedirectToAction(nameof(Index), new { UserId = session.Id });
                }
                catch
                {
                    ViewBag.Error = "this location is not valid";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "this location is not valid";
                return View();
            }
           
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WebUser collection, string Loc)
        {
            if (Loc == "Reston" || Loc == "SanJuan" || Loc == "Tampa" || Loc == "Honolulu" || Loc == "Los Angeles" || Loc == "Kansas")
            {
                try
                {
                    var loc = Repo.FindLocationByAdrress(Loc);
                    Repo.UpdateUser(id, collection.FirstName, collection.LastName, collection.UserName, loc.Id);
                    return RedirectToAction(nameof(Index), new { UserId = id });
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "This location does not exist please try again";
                return View();
            }
            
        }
        
    }
}