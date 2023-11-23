using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;
using WebApplication1.helper;

namespace WebApplication1.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do Usuario")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite o Senha do usuario")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        //a "?" dis que o campo pode ser null
        public DateTime? DataAtuaçozado { get; set; }

        public bool SenhaValida(String senha)
        {
            return Senha == senha.GerarHash();
        }

        //metodo para setar a senha e criar um hash
        public void SetSenhaHash()
        {
            //isso e um metodo de extenção que esta ligado a criptografia pelo "this"
            Senha = Senha.GerarHash();
        }

    }
}