using System.Linq;
using PizzaMoreApp.BindingModels;
using SimpleHttpServer.Models;

namespace PizzaMoreApp.Service
{
    public class VoteForPizzaService :Service
    {
        public void AddVote(VotePizzaBinfingModel model, HttpResponse response)
        {
            var pizzaId = int.Parse(model.PizzaId);
            var pizza = this.contex.Pizzas.First(x => x.Id == pizzaId);
            if (model.PizzaVote == "Up")
            {
                pizza.UpVotes++;
            }
            else
            {
                pizza.DownVotes++;
            }
            this.contex.SaveChanges();
        }
    }
}
