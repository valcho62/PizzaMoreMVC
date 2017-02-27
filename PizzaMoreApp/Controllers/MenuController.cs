using System.Linq;
using PizzaMoreApp.Data;
using PizzaMoreApp.Security;
using PizzaMoreApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMoreApp.Controllers
{
    public class MenuController :Controller
    {
        private SignInManager manager;

        public MenuController()
        {
            this.manager = new SignInManager(new PizzaMoreContex());
        }

        [HttpGet]
        public IActionResult<PizzaSugestionViewModel> Index(HttpSession session, HttpResponse response)
        {
            if (! this.manager.IsAuthenticated(session))
            {
                Redirect(response,"/home/index");
            }
            var contex = new PizzaMoreContex();
            var currentUser = contex.Sessions.First(x => x.SessionId == session.Id).User;
            var model = new PizzaSugestionViewModel()
            {
                Email = currentUser.Email,
                UserSugestions = currentUser.Sugestions
            };
            return this.View(model);
        }
    }
}
