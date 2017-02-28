using System.IO;
using SimpleMVC.Interfaces;

namespace PizzaMoreApp.Views.Menu
{
    public class Add :IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/addpizza.html");
        }
    }
}
