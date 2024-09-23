using JS_Serviços.Models;
using Newtonsoft.Json;

namespace JS_Serviços.Helper
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _httpcontext;

        public Sessao(IHttpContextAccessor httpcontext)
        {
            _httpcontext = httpcontext;
        }
        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpcontext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            _httpcontext.HttpContext.Session.SetString("sessaoUsuarioLogado", JsonConvert.SerializeObject(usuario));
        }

        public void RemoverSessaoUsuario()
        {
            _httpcontext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
