using PizzaMoreApp.Data;
using SimpleHttpServer;
using SimpleMVC;
using SimpleMVC.App;

namespace PizzaMoreApp
{
    class AppStart
    {
        static void Main()
        {
            //var contex = new PizzaMoreContex();
            //contex.Database.Initialize(true);
            HttpServer server = new HttpServer(80, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMoreApp");
        }
    }
}
