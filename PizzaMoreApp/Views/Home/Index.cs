using System.IO;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Views.Home
{
    public class Index :IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home.html");
        }
    }
}
