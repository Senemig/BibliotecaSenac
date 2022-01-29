using System.Collections.Generic;
using System.Collections;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this, HttpContext.Session.GetString("user"));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService usuarioService = new UsuarioService();

            if (u.Id == 0)
            {
                usuarioService.Inserir(u);
            }
            else
            {
                usuarioService.Atualizar(u);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem()
        {
            Autenticacao.CheckLogin(this, HttpContext.Session.GetString("user"));
            UsuarioService usuarioService = new UsuarioService();

            return View(usuarioService.ListarTodos());
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this, HttpContext.Session.GetString("user"));
            UsuarioService usuarioService = new UsuarioService();
            Usuario u = usuarioService.ObterPorId(id);

            return View(u);
        }
    }
}