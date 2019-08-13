using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefsNDishes.Models{  //change projectName to the name of project

    public class NewDishView
    {
        public List<Chef> Chefs{get;set;}
        public Dish newDish{get;set;}
    }
}