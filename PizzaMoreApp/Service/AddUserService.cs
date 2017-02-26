using PizzaMore.Models;
using PizzaMoreApp.BindingModels;

namespace PizzaMoreApp.Service
{
    public class AddUserService :Service
    {
        public AddUserService():base (){}

        public void AddUser(UserBindingModel model)
        {
            User user = new User();
            user.Email = model.Email;
            user.Password = model.Password;
            contex.Users.Add(user);
            contex.SaveChanges();
        }
    }
}
