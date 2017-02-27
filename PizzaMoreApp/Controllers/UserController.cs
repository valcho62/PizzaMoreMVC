using System.Linq;
using PizzaMore.Models;
using PizzaMoreApp.BindingModels;
using PizzaMoreApp.Data;
using PizzaMoreApp.Security;
using PizzaMoreApp.Service;
using PizzaMoreApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Controllers
{
    public class UserController : Controller
    {
        private SignInManager manager;

        public UserController()
        {
            this.manager = new SignInManager(new PizzaMoreContex());
        }
        [HttpGet]
        public IActionResult Signin()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Signin(UserBindingModel model, HttpSession session, HttpResponse response)
        {

            var contex = new PizzaMoreContex();
            var user = contex.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user != null)
            {
                var sessio = new Session();
                sessio.SessionId = session.Id;
                sessio.IsActive = true;
                sessio.User = user;

                contex.Sessions.Add(sessio);
                contex.SaveChanges();
                Redirect(response, "/home/homelog");
                return null;
            }
            Redirect(response, "/home/index");
            return null;
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
            return this.View("Home", "Index");
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            this.manager.Logout(response,session.Id);
            Redirect(response,"/home/index");
            return this.View();
        }
    }
}
