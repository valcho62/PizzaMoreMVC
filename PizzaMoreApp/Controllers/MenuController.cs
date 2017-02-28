using System.Collections.Generic;
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
using SimpleMVC.Interfaces.Generic;

namespace PizzaMoreApp.Controllers
{
    public class MenuController : Controller
    {
        private SignInManager manager;

        public MenuController()
        {
            this.manager = new SignInManager(new PizzaMoreContex());
        }

        [HttpGet]
        public IActionResult<PizzaSugestionViewModel> Index(HttpSession session, HttpResponse response)
        {
            if (!this.manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/index");
            }
            var contex = new PizzaMoreContex();
            var currentUser = contex.Sessions.First(x => x.SessionId == session.Id).User;
            var allPizzas = new List<Pizza>();

            foreach (var user in contex.Users)
            {
                allPizzas.AddRange(user.Sugestions);
            }
            var model = new PizzaSugestionViewModel()
            {
                Email = currentUser.Email,
                UserSugestions = allPizzas
            };
            return this.View(model);
        }
        [HttpPost]
        public IActionResult Index(VotePizzaBinfingModel model, HttpSession session, HttpResponse response)
        {
            if (!this.manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/index");
            }
            VoteForPizzaService service = new VoteForPizzaService();
            service.AddVote(model, response);
            Redirect(response, "/menu/index");
            return null;
        }
        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!this.manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/index");
            }

            return this.View();
        }
        [HttpPost]
        public IActionResult Add(AddPizzaBindingModel model, HttpSession session, HttpResponse response)
        {
            if (!this.manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/index");
                return null;
            }

            var service = new AddPizzaService();
            service.AddPizza(model, session);


            Redirect(response, "/menu/index");
            return null;
        }
        [HttpGet]
        public IActionResult<PizzaSugestionViewModel> Suggestions(HttpSession session, HttpResponse response)
        {
            if (!this.manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/index");
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
