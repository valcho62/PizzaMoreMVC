using System.IO;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Views.User
{
    public class Signin :IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signin.html");
        }
    }
}
