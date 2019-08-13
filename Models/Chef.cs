using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace chefsNDishes.Models{  //change projectName to the name of project

    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="First Name must have at least Four Characters")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Last Name must have at least Four Characters")]
        public string LastName {get;set;}

        [Required(ErrorMessage = "Please enter your Birth Date")]
        [ValidDate]
        public DateTime BirthDate { get; set; }

        public List<Dish> Dishes {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public class ValidDateAttribute : ValidationAttribute   // this validates proper birthdate (before today's date)
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ((DateTime)value > DateTime.Today)
                    return new ValidationResult("Please Enter a Valid Date");
                return ValidationResult.Success;
            }
        }

        public int Age()
        {
            int years = DateTime.Now.Year - BirthDate.Year;

            if((BirthDate.Month > DateTime.Now.Month) || (BirthDate.Month == DateTime.Now.Month && BirthDate.Day > DateTime.Now.Day))
                years--;

            return years;
        }

    }
}