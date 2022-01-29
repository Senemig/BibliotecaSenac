using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario user)
        {

            string s = Criptografo.CriptografarTexto(user.Senha);

            using (BibliotecaContext bc = new BibliotecaContext())
            {

                IQueryable<Usuario> usuario = bc.Usuarios.Where(u => u.Username == user.Username && u.Senha == s);

                if (usuario.Count() > 0)
                {
                    HttpContext.Session.SetString("user", usuario.FirstOrDefault().Username);
                    return RedirectToAction("Index");
                }

                else
                {
                    ViewData["Erro"] = "Usuário ou senha inválida";
                    return View();
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
