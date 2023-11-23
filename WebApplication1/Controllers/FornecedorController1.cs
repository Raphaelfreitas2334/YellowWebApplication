﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.repositorio;

namespace WebApplication1.Controllers
{
    public class FornecedorController1 : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorController1(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index()
        {
            List<FornecedorModel> fornecedor = _fornecedorRepositorio.BuscaTodos();

            return View(fornecedor);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int Id)
        {

            FornecedorModel fornecedor = _fornecedorRepositorio.ListaPorID(Id);

            return View(fornecedor);
        }
        public IActionResult ApagarConfirmacao(int Id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListaPorID(Id);
            return View(fornecedor);
        }
        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _fornecedorRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Fornecedor Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops. nao consiguimos Excluir o Fornecedor, temte novamente";
                }


                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Excluir o alimento, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fornecedor = _fornecedorRepositorio.Adicionar(fornecedor);

                    TempData["MensagemSucesso"] = "Fornecedor cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(fornecedor);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops. nao consiguimos cadastra o Fornecedor, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Alterar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Atualizar(fornecedor);
                    TempData["MensagemSucesso"] = "Fornecedor Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", fornecedor);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Atualizar o Fornecedor, temte novamente: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
