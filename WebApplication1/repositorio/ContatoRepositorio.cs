using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _Context;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _Context = bancoContext;
        }

        public ContatoModel ListaPorID(int id)
        {
            return _Context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscaTodos()
        {
            return _Context.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _Context.Contatos.Add(contato);
            _Context.SaveChanges();

            return contato; 

        }

        public List<ContatoModel> BuscaTodos(int id)
        {
            throw new System.NotImplementedException();
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            //aqui esta buscando  pelo Id
            ContatoModel contatoDB = ListaPorID(contato.Id);
            // esse e um if para ver se o id esta fazio se sem mostra o erro abaixo
            if (contatoDB == null) throw new System.Exception("Houve um erro na Atualização do alimento!");
            //aqui estamos setando os falores nos campos respectivos no banco de dados
            contatoDB.Nome = contato.Nome;
            contatoDB.Medida = contato.Medida;
            contatoDB.Categoria = contato.Categoria;
            contatoDB.Fornecedor = contato.Fornecedor;
            //mandadno os dados para o banco
            _Context.Contatos.Update(contatoDB);
            _Context.SaveChanges();
            
            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListaPorID(id);
            
            if (contatoDB == null) throw new System.Exception("Houve um erro na deleçaõ do alimento!");

            _Context.Contatos.Remove(contatoDB);
            _Context.SaveChanges();

            return true;
        }
    }
}
