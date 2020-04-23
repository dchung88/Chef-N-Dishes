using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefs_Dishes.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int DishId {get;set;}

        [Required]
        public string DishName {get;set;}

        [Required]
        public int Calories {get;set;}

        [Required]
        // [Range(1, 5)]
        public int Tastiness {get;set;}

        [Required]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [Required]
        public int ChefId {get;set;}

        public Chef Creator {get;set;}
    }
}