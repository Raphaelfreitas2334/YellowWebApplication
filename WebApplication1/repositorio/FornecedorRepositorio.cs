using ControleDeContatos.Data;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly BancoContext _Context;

        public FornecedorRepositorio(BancoContext bancoContext)
        {
            _Context = bancoContext;
        }

        public FornecedorModel ListaPorID(int id)
        {
            return _Context.Fornecedor.FirstOrDefault(x => x.Id == id);
        }

        public List<FornecedorModel> BuscaTodos()
        {
            return _Context.Fornecedor.ToList();
        }

        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _Context.Fornecedor.Add(fornecedor);
            _Context.SaveChanges();

            return fornecedor;

        }

        public List<FornecedorModel> BuscaTodos(int id)
        {
            throw new System.NotImplementedException();
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            //aqui esta buscando  pelo Id
            FornecedorModel fornecedorDB = ListaPorID(fornecedor.Id);
            // esse e um if para ver se o id esta fazio se sem mostra o erro abaixo
            if (fornecedorDB == null) throw new System.Exception("Houve um erro na Atualização do alimento!");
            //aqui estamos setando os falores nos campos respectivos no banco de dados
            fornecedorDB.Nome = fornecedor.Nome;
            fornecedorDB.CNPJ = fornecedor.CNPJ;
            fornecedorDB.Telefone = fornecedor.Telefone;
            fornecedorDB.Endereço = fornecedor.Endereço;
            //mandadno os dados para o banco
            _Context.Fornecedor.Update(fornecedorDB);
            _Context.SaveChanges();

            return fornecedorDB;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListaPorID(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na deleçaõ do alimento!");

            _Context.Fornecedor.Remove(fornecedorDB);
            _Context.SaveChanges();

            return true;
        }
    }
}
