using System;
using PizzaMore.Models;

namespace PizzaMoreApp.Data.Interfaces
{
    public interface IUnitOfWorks :IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Pizza> Pizzas { get; }
        IRepository<Session> Sessions { get; }

        void Commit();
    }
}