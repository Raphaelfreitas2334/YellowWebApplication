using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Fornecedor")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CNPJ do Fornecedor")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Digite o Telefone do Fornecedor")]
        [Phone(ErrorMessage = "Digite o Telefone do Fornecedor")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o Endereço do Fornecedor")]
        public string Endereço { get; set; }

    }
}
