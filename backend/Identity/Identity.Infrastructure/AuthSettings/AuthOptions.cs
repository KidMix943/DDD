﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Infrastructure.AuthSettings
{
	public static class AuthOptions
	{
		public const string ISSUER = "MyAuthServer"; 
		public const string AUDIENCE = "MyAuthClient"; 
		const string KEY = "mysupersecret_secretkey!123"; 
		public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
	}
}
