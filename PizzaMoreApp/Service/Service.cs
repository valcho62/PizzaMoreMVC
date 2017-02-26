using PizzaMoreApp.Data;

namespace PizzaMoreApp.Service
{
    public abstract class Service
    {
        public PizzaMoreContex contex;

        protected Service()
        {
            this.contex = new PizzaMoreContex();
        }
    }
}
