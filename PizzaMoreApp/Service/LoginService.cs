using System.Linq;
using System.Runtime.InteropServices;
using PizzaMore.Models;
using PizzaMoreApp.BindingModels;
using SimpleHttpServer.Models;

namespace PizzaMoreApp.Service
{
    public class LoginService :Service
    {
        public LoginService(): base()
        {
            
        }
        public bool LoginUser(UserBindingModel model, HttpSession session)
        {
            var user = contex.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user != null)
            {
                var sessio = new Session();
                sessio.SessionId = session.Id;
                sessio.IsActive =true;
                sessio.User = user;

                contex.Sessions.Add(sessio);
                contex.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
