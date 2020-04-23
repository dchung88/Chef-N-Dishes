using Microsoft.EntityFrameworkCore;
 
namespace Chefs_Dishes.Models
{
    public class ChefsDishesContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ChefsDishesContext(DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }
}