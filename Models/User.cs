using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsNDishes.Models{  //change projectName to the name of project
    
    public class User
    {
        [Key]
        public int UserId {get;set;}


        [Required]
        [MinLength(4, ErrorMessage="Last Name must have at least Four Characters")]
        public string FirstName {get;set;}


        [Required]
        [MinLength(4, ErrorMessage="Last Name must have at least Four Characters")]
        public string LastName {get;set;}


        [Required(ErrorMessage = "Please enter your Birth Date")]
        [ValidDate]
        public DateTime BirthDate { get; set; }


        [Required]
        [EmailAddress(ErrorMessage="Enter a Valid Email Address!")]
        public string Email {get;set;}

        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
        // Will not be mapped to your users table!
        [NotMapped]                                             // this validates password matching
        [Compare("Password", ErrorMessage="Passwords Do Not Match; Please Try Again")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get;set;}


        public class ValidDateAttribute : ValidationAttribute   // this validates proper birthdate (before today's date)
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ((DateTime)value > DateTime.Today)
                    return new ValidationResult("Please Enter a Valid Date");
                return ValidationResult.Success;
            }
        }
    }
} 


