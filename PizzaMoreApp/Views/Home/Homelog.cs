using System.IO;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Views.Home
{
    public class Homelog :IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home-logged.html");
        }
    }
}
