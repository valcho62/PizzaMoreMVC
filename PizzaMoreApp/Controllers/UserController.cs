using PizzaMoreApp.BindingModels;
using PizzaMoreApp.Service;
using PizzaMoreApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Controllers
{
    public class UserController :Controller
    {
        [HttpGet]
        public IActionResult Signin()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Signin(UserBindingModel model, HttpSession session)
        {
            var service = new LoginService();
            if (service.LoginUser(model,session))
            {
                Redirect(new HttpResponse(), "/home-logged.html");
                return null;
            }
            return this.View("Home", "Index");
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Signup(UserBindingModel model)
        {
            AddUserService service = new AddUserService();
            service.AddUser(model);
            return this.View("Home","Index");
        }
    }
}
