using Microsoft.EntityFrameworkCore;

namespace chefsNDishes.Models //change projectName to the name of project
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Chef> Chefs {get;set;} // needs one line for each Model.cs file created, 
        public DbSet<Dish> Dishes {get;set;} //Chef is Model Name, Chefs is the Db Property & Table Name
    }
}