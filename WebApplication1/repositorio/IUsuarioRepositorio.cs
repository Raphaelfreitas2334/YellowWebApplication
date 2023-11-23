//WebApplication1 e o nome do programa 
using ControleDeContatos.Models;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> BuscaTodos();
        UsuarioModel ListaPorID(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}
