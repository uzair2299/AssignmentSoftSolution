using AssignmentSoftSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentSoftSolution.Controllers
{
    public class CityController : Controller
    {
        private ApplicationContext _ApplicationContext;
        public CityController()
        {
            _ApplicationContext = new ApplicationContext();
        }
        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(City city)
        {
            if (ModelState.IsValid)
            {
             City AddedCity  = _ApplicationContext.Cities.Add(city);
                _ApplicationContext.SaveChanges();
                ViewBag.AddMsg = AddedCity.CityName +"Added Successfully";
                return View();
            }
            return View();
        }
    }
}