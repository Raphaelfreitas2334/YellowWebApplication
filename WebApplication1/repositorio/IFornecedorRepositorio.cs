﻿
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.repositorio
{
    public interface IFornecedorRepositorio
    {
        FornecedorModel ListaPorID(int id);
        List<FornecedorModel> BuscaTodos();
        FornecedorModel Adicionar(FornecedorModel fornecedor);
        FornecedorModel Atualizar(FornecedorModel fornecedor);
        bool Apagar(int id);
    }
}
