using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Services
{
	public static class AuthenticationService
	{
		public static IServiceCollection GetAuthService(this IServiceCollection services, IConfiguration configuration)
		{
			var secretkey = configuration.GetSection("SecretKey").Value;
			var simmetricKey = ASCIIEncoding.ASCII.GetBytes(secretkey);

			TokenValidationParameters validationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(simmetricKey),
				ValidateIssuer = false,
				ValidateAudience = false,
				ClockSkew = TimeSpan.Zero
			};

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(opt => opt.TokenValidationParameters = validationParameters);

			return services;
		}
	}
}
