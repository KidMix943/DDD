using Identity.Infrastructure.AuthSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Identity.Routes
{
	public static class IdentityRoute
	{
		public static WebApplication AddIdentytiRouter(this WebApplication application)
		{
			application.MapPost("/login/{username}", CreateJwtToken);
			application.MapGet("/data", [Authorize] () => new { message = "Hello World!" });
			return application;

		}
		static string CreateJwtToken (string username)
		{
			var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
			// создаем JWT-токен
			var jwt = new JwtSecurityToken(
				issuer: AuthOptions.ISSUER,
				audience: AuthOptions.AUDIENCE,
				claims: claims,
				expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
				signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
	}
}
