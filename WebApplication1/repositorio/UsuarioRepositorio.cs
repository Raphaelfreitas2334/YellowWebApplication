using ControleDeContatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _Context;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _Context = bancoContext;
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _Context.Usuario.FirstOrDefault(X => X.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListaPorID(int id)
        {
            return _Context.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscaTodos()
        {
            return _Context.Usuario.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _Context.Usuario.Add(usuario);
            _Context.SaveChanges();
            return usuario;

        }

        public List<UsuarioModel> BuscaTodos(int id)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            //aqui esta buscando  pelo Id
            UsuarioModel usuarioDB = ListaPorID(usuario.Id);
            // esse e um if para ver se o id esta fazio se sem mostra o erro abaixo
            if (usuarioDB == null) throw new System.Exception("Houve um erro na Atualização do alimento!");
            //aqui estamos setando os falores nos campos respectivos no banco de dados
            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtuaçozado = DateTime.Now;
            //mandadno os dados para o banco
            _Context.Usuario.Update(usuarioDB);
            _Context.SaveChanges();

            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListaPorID(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleçaõ do alimento!");

            _Context.Usuario.Remove(usuarioDB);
            _Context.SaveChanges();

            return true;
        }

        
    }
}
