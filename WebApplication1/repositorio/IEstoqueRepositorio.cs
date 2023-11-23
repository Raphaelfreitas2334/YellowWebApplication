//WebApplication1 e o nome do programa 
using ControleDeContatos.Models;
using System.Collections.Generic;

namespace WebApplication1.repositorio
{
    public interface IEstoqueRepositorio
    {
        EstoqueModel ListaPorID(int id);
        List<EstoqueModel> BuscaTodos();
        EstoqueModel Adicionar(EstoqueModel estoque);
        EstoqueModel Atualizar(EstoqueModel estoque);
        bool Apagar(int id);
    }
}
