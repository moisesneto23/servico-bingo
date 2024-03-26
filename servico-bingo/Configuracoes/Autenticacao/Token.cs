using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;


namespace OrcamentoPortaoGenerico.Api.Configuracoes 
{
	public class Token
	{
		public static string GerarToken(string adm)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
			var key = Encoding.ASCII.GetBytes(jAppSettings["ChaveSecreta"].ToString());
			var expirationTime = Convert.ToInt32(jAppSettings["TempoExpiracao"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new Claim[]{
						//new Claim(ClaimTypes.PostalCode, adm.CodigoEmpresa.ToString()),
						new Claim(ClaimTypes.Name, adm),
						//new Claim(ClaimTypes.Role, adm.Permissao),
					}),
				// Expires = DateTime.UtcNow.AddHours(expirationTime),
				Expires = DateTime.UtcNow.AddHours(expirationTime),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
