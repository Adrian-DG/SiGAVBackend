
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Helpers
{
	public class TokenHelper
	{
		private readonly IConfiguration _configuration;
		public TokenHelper(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GenerateToken(Usuario usuario)
		{
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
				new Claim(ClaimTypes.Name, usuario.Username),
			};

			var SecretKey = _configuration.GetSection("SecretKey").Value;
			var SimmetricKey = new SymmetricSecurityKey(ASCIIEncoding.UTF8.GetBytes(SecretKey));

			SigningCredentials credentials = new SigningCredentials(SimmetricKey, SecurityAlgorithms.HmacSha512Signature);

			SecurityTokenDescriptor tokenDecriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddHours(8),
				SigningCredentials = credentials
			};

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken token = tokenHandler.CreateToken(tokenDecriptor);

			return tokenHandler.WriteToken(token);

		}

		public string GenerateUnitToken(string ficha)
		{
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier, ficha),
				new Claim(ClaimTypes.Name, ficha)
			};

			var SecretKey = _configuration.GetSection("SecretKey").Value;
			var SimmetricKey = new SymmetricSecurityKey(ASCIIEncoding.UTF8.GetBytes(SecretKey));

			SigningCredentials credentials = new SigningCredentials(SimmetricKey, SecurityAlgorithms.HmacSha512Signature);

			SecurityTokenDescriptor tokenDecriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddHours(8),
				SigningCredentials = credentials
			};

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken token = tokenHandler.CreateToken(tokenDecriptor);

			return tokenHandler.WriteToken(token);

		}

	}
}
