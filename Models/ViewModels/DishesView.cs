using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefsNDishes.Models{  //change projectName to the name of project

    public class DishesView
    {
        public List<Dish> Dishes{get;set;}
    }
}