using PizzaMoreApp.Data;
using PizzaMoreApp.Security;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Controllers
{
    public class HomeController :Controller
    {
        public SignInManager manager;
        PizzaMoreContex contex = new PizzaMoreContex();
        public HomeController()
        {

            this.manager = new SignInManager(contex);
        }
        public IActionResult Index(HttpSession session,HttpResponse response)
        {
            if (this.manager.IsAuthenticated(session))
            {
                Redirect(response,"/home/homelog");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Homelog(HttpSession session)
        {
            return View();
        }
    }
}
