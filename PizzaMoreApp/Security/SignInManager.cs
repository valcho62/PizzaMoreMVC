using System.Linq;
using PizzaMoreApp.Data;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace PizzaMoreApp.Security
{
   public class SignInManager
   {
       private PizzaMoreContex contex;

       public SignInManager(PizzaMoreContex contex)
       {
           this.contex = contex;
       }

       public bool IsAuthenticated(HttpSession session)
       {
           return this.contex.Sessions.Any(x => x.IsActive && x.SessionId == session.Id);
       }

       public void Logout(HttpResponse response, string sessionId)
       {
           var currentSession = this.contex.Sessions.FirstOrDefault(x => x.SessionId == sessionId);
           currentSession.IsActive = false;
           this.contex.SaveChanges();

           var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId",session.Id + "HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
       }
   }
}
