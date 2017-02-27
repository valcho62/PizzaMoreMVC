using System.Collections.Generic;
using PizzaMore.Models;

namespace PizzaMoreApp.ViewModels
{
    public class PizzaSugestionViewModel
    {
        public string Email { get; set; }
        public ICollection<Pizza> UserSugestions { get; set; }
    }
}
