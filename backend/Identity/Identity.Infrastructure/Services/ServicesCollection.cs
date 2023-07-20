using Identity.Infrastructure.AuthSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Infrastructure.Services
{
	public static class ServicesCollection
	{
		public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = AuthOptions.ISSUER,

				ValidateAudience = true,
				ValidAudience = AuthOptions.AUDIENCE,

				ValidateLifetime = true,

				IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
				ValidateIssuerSigningKey = true,
			};
				});
			return services;
		}

	}
}
