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
    public class LocationController : Controller
    {
        public Repository Repo { get; }
        // GET: Location
        public LocationController(Repository repo)
        {
            Repo = repo;
        }
        [Route ("Index")]
        public ActionResult Index()
        {
            var libLocations = Repo.DisplayLocation();
           
            var wbLocation = libLocations.Select(x => new WebLocation
            {
                Id = x.Id,
                AdressLine1 = x.AdressLine1
                , AdressLine2 = x.AdressLine2
                , ZipCode = x.ZipCode
                
                
            });
            return View(wbLocation);
        }

        // GET: Location/Details/5
        [Route ("Index/Order/{id?}")]
        public ActionResult Order(int id)
        {
          
            var libLocation = Repo.FindLocationByID(id);
           
            var wbLocation = new WebLocation
            {
                AdressLine1 = libLocation.AdressLine1,
                AdressLine2 = libLocation.AdressLine2,
                Id = libLocation.Id,
                ZipCode = libLocation.ZipCode, 
     
            };
            return View(wbLocation);
        }

    }
}