using System.Security.Claims;
using System.Security.Principal;

namespace OrcamentoGenerico.Api.Configuracoes
{
    public class JwtTokenIdentityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public JwtTokenIdentityMiddleware(RequestDelegate next,
                                          ILogger<JwtTokenIdentityMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext context)
        {
            IIdentity identity = context.User.Identity;

            if (identity != null && identity.IsAuthenticated)
            {
                IEnumerable<Claim> userClaims = context.User.Claims;

                if (IsUser(userClaims))
                {
                    context.Request.Headers["IsUsuario"] = "true";
                }

                context.Request.Headers["PreferredUsername"] = GetPreferredUsername(userClaims);
            }

            return _next(context);
        }

        private bool IsUser(IEnumerable<Claim> userClaims)
        {
            List<Claim> claims = new List<Claim>() { new Claim("isUsuario", "true") };

            return userClaims.Any(x => claims.Any(c => c.Type == x.Type && c.Value == x.Value));
        }

        private string GetPreferredUsername(IEnumerable<Claim> userClaims)
        {
            Claim claim = userClaims.FirstOrDefault(c => c.Type == "preferred_username");

            if (claim != null)
            {
                return claim.Value;
            }

            _logger.LogWarning("Sem identificação do preferred_username no token.", userClaims);

            return "";
        }
    }
}
