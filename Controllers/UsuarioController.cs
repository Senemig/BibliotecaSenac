using System.Collections.Generic;
using System.Collections;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
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
            UsuarioService usuarioService = new UsuarioService();

            return View(usuarioService.ListarTodos());
        }

        public IActionResult Edicao(int id)
        {
            UsuarioService usuarioService = new UsuarioService();
            Usuario u = usuarioService.ObterPorId(id);

            return View(u);
        }
    }
}