using PizzaMore.Models;

namespace PizzaMoreApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaMoreContex : DbContext
    {
        
        public PizzaMoreContex()
            : base("name=PizzaMoreContex")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
    }

   
}