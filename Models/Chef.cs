using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Chefs_Dishes.Models
{
    public class Chef
    {
        [Key]
        [Required]
        public int ChefId {get;set;}

        [Required]
        public string FirstName {get;set;}

        [Required]
        public string LastName {get;set;}

        [Required]
        public DateTime Birthday {get;set;}
        
        public int Age
        {
            get{return DateTime.Now.Year - Birthday.Year;}
        }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Dish> MadeDishes {get;set;}

    }

}