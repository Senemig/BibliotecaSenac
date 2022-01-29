using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Biblioteca.Controllers
{
    public class Autenticacao
    {
        public static void CheckLogin(Controller controller, string admin = "")
        {   

            if(string.IsNullOrEmpty(controller.HttpContext.Session.GetString("user")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }

            else{
                if (!string.IsNullOrEmpty(admin))
                {
                    if(controller.HttpContext.Session.GetString("user") != "admin")
                    {
                        controller.Request.HttpContext.Response.Redirect("/Home/Login");
                    }
                }
            }
        }
    }
}