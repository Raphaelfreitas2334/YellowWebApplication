using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.repositorio
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly BancoContext _Context;

        public EstoqueRepositorio(BancoContext bancoContext)
        {
            _Context = bancoContext;
        }

        public EstoqueModel ListaPorID(int id)
        {
            return _Context.Estoque.FirstOrDefault(x => x.Id == id);
        }

        public List<EstoqueModel> BuscaTodos()
        {
            return _Context.Estoque.ToList();
        }

        public EstoqueModel Adicionar(EstoqueModel estoque)
        {
            _Context.Estoque.Add(estoque);
            _Context.SaveChanges();

            return estoque; 

        }

        public List<EstoqueModel> BuscaTodos(int id)
        {
            throw new System.NotImplementedException();
        }

        public EstoqueModel Atualizar(EstoqueModel estoque)
        {
            //aqui esta buscando  pelo Id
            EstoqueModel estoqueDB = ListaPorID(estoque.Id);
            // esse e um if para ver se o id esta fazio se sem mostra o erro abaixo
            if (estoqueDB == null) throw new System.Exception("Houve um erro na Atualização do alimento!");
            //aqui estamos setando os falores nos campos respectivos no banco de dados
            estoqueDB.QuantidadeFinal = estoque.QuantidadeFinal;
            estoqueDB.Saldo = estoque.Saldo;
            estoqueDB.DataEntrada = estoque.DataEntrada;
            //mandadno os dados para o banco
            _Context.Estoque.Update(estoqueDB);
            _Context.SaveChanges();
            
            return estoqueDB;
        }

        public bool Apagar(int id)
        {
            EstoqueModel contatoDB = ListaPorID(id);
            
            if (contatoDB == null) throw new System.Exception("Houve um erro na deleçaõ do alimento!");

            _Context.Estoque.Remove(contatoDB);
            _Context.SaveChanges();

            return true;
        }
    }
}
