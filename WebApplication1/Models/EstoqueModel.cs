using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Digite o nome do alimento")] 

        public int QuantidadeFinal { get; set; }
        [Required(ErrorMessage = "Digite o saldo do alimento")]
        public int Saldo { get; set; }
        [Required(ErrorMessage = "Digite o fornecedor do alimento")]
        public DateTime DataEntrada { get; set; }

        /* para validar e-mail e assim [EmailAddress(ErroMessage = "mensagem")]
         * para validar celular e assim [Phone(ErroMessage = "mensagem")]
         */
    }
}