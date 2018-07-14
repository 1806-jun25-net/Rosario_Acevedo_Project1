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
    public class UserController : Controller
    {
        // GET: User 
        public Repository Repo { get; }

        public UserController(Repository repo)
        {
            Repo = repo;
        }
        [Route ("Home/User")]
        public ActionResult Index([FromQuery]int id)
        {
            var session = Repo.FindUserByID(id);
            if (session != null)
            {
                List<WebUser> wUser = new List<WebUser>();
                wUser.Add( new WebUser {
                        FirstName = session.FirstName, 
                        LastName = session .LastName, 
                        Id = session.Id, 
                        UserName = session.UserName
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

        // GET: User/Details/5
       // [Route("Home/User/{id?}")]
        public ActionResult Details([FromQuery]int id)
        {
            var libUser = Repo.FindUserByID(id);
            var wbUser = new WebUser
            {
                FirstName = libUser.FirstName,
                LastName = libUser.LastName,
                Id = libUser.Id,
                UserName = libUser.UserName
            };
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}