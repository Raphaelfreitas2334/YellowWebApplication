using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<FornecedorModel> Fornecedor { get; set; }
        public DbSet<EstoqueModel> Estoque { get; set; }

    }
}