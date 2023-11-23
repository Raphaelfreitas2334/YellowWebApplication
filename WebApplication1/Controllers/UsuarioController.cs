using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.repositorio;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio UsuarioRepositorio)
        {
            _UsuarioRepositorio = UsuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _UsuarioRepositorio.BuscaTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {

            UsuarioModel usuario = _UsuarioRepositorio.ListaPorID(Id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.ListaPorID(Id);
            return View(usuario);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _UsuarioRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops. nao consiguimos Excluir o Usuario, temte novamente";
                }


                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Excluir o Usuario, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _UsuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. nao consiguimos cadastra o Usuario, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsusarioSemSenhaModel ususarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = ususarioSemSenhaModel.Id,
                        Name = ususarioSemSenhaModel.Name,
                        Login = ususarioSemSenhaModel.Login,
                        Email = ususarioSemSenhaModel.Email,
                        Perfil = ususarioSemSenhaModel.Perfil
                    };

                    usuario = _UsuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Atualizar o Usuario, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
    }