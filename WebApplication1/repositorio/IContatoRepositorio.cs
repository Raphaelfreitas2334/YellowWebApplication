//WebApplication1 e o nome do programa 
using ControleDeContatos.Models;
using System.Collections.Generic;

namespace WebApplication1.repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListaPorID(int id);
        List<ContatoModel> BuscaTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
