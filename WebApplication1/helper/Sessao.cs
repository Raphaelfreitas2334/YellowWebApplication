using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContex;

        public Sessao(IHttpContextAccessor httpContex)
        {
            _httpContex = httpContex;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            //aqui esta pegando o usuario Buscado e solocando em uma String para convertelo novamente em um objeto
            string sessaoUsuario = _httpContex.HttpContext.Session.GetString("sessaoUsuarioLogado");
            //if simples para ver se existe ou nao usuario
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            //se existe aqui esta comvertento o usuario de string para objeto
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            //quando se cria uma sessao ele vai converter o objeto usuaio em um json
            string valor = JsonConvert.SerializeObject(usuario);
            //nessa linha esta convertendo o objeto usuario para um json
            _httpContex.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaUsuario()
        {
            //simplismente removendo a sesao do usuario
            _httpContex.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
