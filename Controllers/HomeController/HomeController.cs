using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http; // FOR USE OF SESSIONS
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using chefsNDishes.Models; //change projectName to the name of project

namespace chefsNDishes.Controllers  //change projectName to the name of project
{
    public class HomeController : Controller{
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]               
        public IActionResult Index(){
            return RedirectToAction("DisplayChefs");
        }

        [HttpGet("chefs")]
        public IActionResult DisplayChefs(){
            ChefsView viewModel = new ChefsView();
            viewModel.Chefs = dbContext.Chefs
                .Include(d => d.Dishes)
                .ToList();
            
            return View("ChefDisplay", viewModel);
        }

        [HttpGet("newChef")]
        public IActionResult NewChef(){
            return View("NewChef");
        }

        [HttpPost("addChef")]
        public IActionResult AddChef(NewChefView modelView)
        {
            if(ModelState.IsValid){
                    Chef newChef = modelView.newChef;

                    dbContext.Add(newChef);
                    dbContext.SaveChanges();
                    return RedirectToAction("DisplayChefs");
                }

                return View("NewChef");
        }

        [HttpGet("dishes")]
        public IActionResult DisplayDishes(){
            DishesView viewModel = new DishesView();
            viewModel.Dishes = dbContext.Dishes
            .Include(d => d.chef)
            .ToList();

            return View("DishDisplay", viewModel);
        }
        
        [HttpGet("newDish")]
        public IActionResult NewDish(){
            NewDishView viewModel = new NewDishView();
            viewModel.Chefs = dbContext.Chefs.ToList();
            return View("NewDish", viewModel);
        }

        [HttpPost("addDish")]
        public IActionResult AddDish(NewDishView modelView){
            if(ModelState.IsValid){
                Dish newDish = modelView.newDish;

                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("DisplayDishes");
            }

            return View("NewDish");
        }
    }
}