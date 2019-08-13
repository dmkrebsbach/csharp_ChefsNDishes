using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsNDishes.Models{  //change projectName to the name of project

    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Required]
        [MinLength(4, ErrorMessage="Dish Name must have at least Four Characters")]
        public string Name {get;set;}

        [Required]
        [Range(1,5)]
        public int Tastiness { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ChefId { get; set; }

        public Chef chef { get; set; }

        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        

    }
}