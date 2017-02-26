using System.IO;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Views.User
{
    public class Signup:IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signup.html");
        }
    }
}
