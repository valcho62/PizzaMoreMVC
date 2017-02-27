using PizzaMore.Models;
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
            //var ses = new Session();
            //ses.IsActive = true;
            //ses.SessionId = "12";
            //contex.Sessions.Add(ses);
            //contex.SaveChanges();
            //contex.Database.Initialize(true);
            HttpServer server = new HttpServer(80, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMoreApp");
        }
    }
}
