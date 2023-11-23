using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.repositorio;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        /*essa private tem que existir para que possa ser acessado o IcontatoControle
         * pois se nao não tem como fazer acesso a ela, com isso concluimos o metodo post
         * do criar
        */
        /*ps: o "_" siginifica que o metodo e do tipo privado ou seja quano for usar ele
         * dentro da public contatoController tem que usar o "_" antes do metodo 
        */

        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contato = _contatoRepositorio.BuscaTodos();

            return View(contato);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            /* muita atenção por algum motivo porcebi que tem que escrever
             * essa linha de codigo ao contrario ou seja começa assim
             * _contatoRepositorio.ListaPorID(id);
             * depois acresenta isso
             * ContatoModel contato = 
             * no final junta tudo assim
             * ContatoModel contato = _contatoRepositorio.ListaPorID(Id);
             */
            ContatoModel contato = _contatoRepositorio.ListaPorID(Id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            ContatoModel contato = _contatoRepositorio.ListaPorID(Id);
            return View(contato);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Alimento Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops. nao consiguimos Excluir o alimento, temte novamente";
                }

                
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Excluir o alimento, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]//aqui eu estou assindo que o metodo abaixo será do tipo post
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contato = _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Alimento cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. nao consiguimos cadastra o alimento, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Alimento Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato); 
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Atualizar o alimento, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}