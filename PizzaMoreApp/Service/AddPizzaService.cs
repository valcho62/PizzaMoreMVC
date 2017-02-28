using System.Linq;
using PizzaMore.Models;
using PizzaMoreApp.BindingModels;
using SimpleHttpServer.Models;

namespace PizzaMoreApp.Service
{
    public class AddPizzaService : Service
    {
        public AddPizzaService():base (){ }

        public void AddPizza(AddPizzaBindingModel model,HttpSession session)
        {
            var user = this.contex.Sessions.First(x => x.SessionId == session.Id).User;
            Pizza pizza = new Pizza();
            pizza.Title = model.Title;
            pizza.Recipe = model.Recipe;
            pizza.ImageUrl = model.ImageUrl;
            pizza.Owner = user;
            contex.Pizzas.Add(pizza);
            contex.SaveChanges();
        }
    }
}
