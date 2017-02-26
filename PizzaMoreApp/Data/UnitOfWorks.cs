using System.Data.Entity;
using PizzaMore.Models;
using PizzaMoreApp.Data.Interfaces;

namespace PizzaMoreApp.Data
{
   public class UnitOfWorks :IUnitOfWorks
   {
       private DbContext contex;

       public UnitOfWorks()
       {
           this.contex = new PizzaMoreContex();
       }

       private IRepository<User> users;
       private IRepository<Pizza> pizzas;
       private IRepository<Session> sessions;

       public IRepository<Session> Sessions { get; }

       public void Commit()
       {
           this.contex.SaveChanges();
       }

       public IRepository<User> Users
       {
           get { return this.users ?? (this.users = new Repository<User>(this.contex)); }
       }

       public IRepository<Pizza> Pizzas { get; }

       public void Dispose()
       {
           this.contex.Dispose();
       }
   }
}
