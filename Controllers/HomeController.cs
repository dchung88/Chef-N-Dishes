using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chefs_Dishes.Models;

namespace Chefs_Dishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsDishesContext dbContext;
        public HomeController(ChefsDishesContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            List<Chef> chefslist = dbContext.Chefs.Include(c => c.MadeDishes).OrderByDescending(c => c.UpdatedAt).ToList();
            ViewBag.AllChefs = chefslist;
            return View("Index", chefslist);
        }

        [HttpGet]
        [Route("new")]
        public ViewResult NewChef()
        {
            return View("AddChef");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }

        [HttpGet]
        [Route("dishes")]
        public ViewResult Dishes()
        {
            List<Dish> dishlist = dbContext.Dishes.Include(d => d.Creator).ToList();
            ViewBag.AllDishes = dishlist;
            return View("Dishes");
        }

        [HttpGet]
        [Route("dish/new")]
        public IActionResult NewDish()
        {
            // List<Chef> chefslist = dbContext.Chefs.ToList();
            // ViewBag.AllChefs = chefslist;
            ViewBag.AllChefs = dbContext.Chefs.ToList();
            return View("AddDish");
        }

        [HttpPost]
        [Route("AddedDish")]
        public IActionResult AddDish(Dish newDish)
        {

            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                ViewBag.AllChefs = dbContext.Chefs.ToList();
                return View("AddDish");
            }
        }

    }
}
