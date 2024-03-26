
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace OrcamentoGenerico.Api.Configuracoes
{

    public static class ApplicationContext
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static HttpContext Current { get { return _httpContextAccessor.HttpContext; } }

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static UsuarioAtualVO ObterUsuarioAtual()
        {
            string nomeCompleto = $"{ObterValorClaim(ClaimTypes.GivenName)} {ObterValorClaim(ClaimTypes.Surname)}";

            string login = ObterValorClaim(ClaimTypes.NameIdentifier);

            string email = ObterValorClaim(ClaimTypes.Email);

            return new UsuarioAtualVO(nomeCompleto, login, email);
        }

        private static string ObterValorClaim(string claimName)
        {
            var claimsUsuario = Current.User.Claims;

            return claimsUsuario.FirstOrDefault(c => c.Type.Equals(claimName)).Value;
        }
    }
}