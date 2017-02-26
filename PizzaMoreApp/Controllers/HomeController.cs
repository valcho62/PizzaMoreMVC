using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Controllers
{
    public class HomeController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
