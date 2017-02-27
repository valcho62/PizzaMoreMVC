using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMoreApp.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMoreApp.Views.Menu
{
    public class Index : IRenderable<PizzaSugestionViewModel>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine("<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                "<div class=\"navbar-header\">" +
                "<a class=\"navbar-brand\" href=\"/home/index\">PizzaMore</a>" +
                "</div>" +
                "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                "<ul class=\"nav navbar-nav\">" +
                "<li ><a href=\"/menu/add\">Suggest Pizza</a></li>" +
                "<li><a href=\"/menu/suggestions\">Your Suggestions</a></li>" +
                "</ul>" +
                "<ul class=\"nav navbar-nav navbar-right\">" +
                "<p class=\"navbar-text navbar-right\"></p>" +
                "<p class=\"navbar-text navbar-right\"><a href=\"/users/logout\" class=\"navbar-link\">Sign Out</a></p>" +
                $"<p class=\"navbar-text navbar-right\">Signed in as {this.Model.Email}</p>" +
                "</ul> </div></div></nav>");

            htmlContent.AppendLine(File.ReadAllText("../../content/menu-top.html"));
            htmlContent.AppendLine("<div class=\"card-deck\">");
            foreach (var pizza in this.Model.UserSugestions)
            {
                htmlContent.AppendLine("<div class=\"card\">");
                htmlContent.AppendLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                htmlContent.AppendLine("<div class=\"card-block\">");
                htmlContent.AppendLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                htmlContent.AppendLine($"<p class=\"card-text\"><a href=\"/menu/details?pizzaId={pizza.Id}\">Recipe</a></p>");
                htmlContent.AppendLine("<form method=\"POST\">");
                htmlContent.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"PizzaVote\" value=\"Up\">Up</label></div>");
                htmlContent.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"PizzaVote\" value=\"Down\">Down</label></div>");
                htmlContent.AppendLine($"<input type=\"hidden\" name=\"PizzaId\" value=\"{pizza.Id}\" />");
                htmlContent.AppendLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                htmlContent.AppendLine("</form>");
                htmlContent.AppendLine("</div>");
                htmlContent.AppendLine("</div>");
            }
            htmlContent.AppendLine("</div>");

            htmlContent.AppendLine(File.ReadAllText("../../content/menu-bottom.html"));

            return htmlContent.ToString();
        }

        public PizzaSugestionViewModel Model { get; set; }
    }
}
