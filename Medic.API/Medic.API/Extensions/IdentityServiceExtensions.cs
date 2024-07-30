using Mapster;
using Medic.API.Data;
using Medic.API.Helpers;
using Medic.API.Interfaces;
using Medic.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Medic.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding
                             .UTF8.GetBytes(configuration["TokenKey"])),
                         ValidateIssuer = false,
                         ValidateAudience = false
                     };
                });

            return services;
        }
    }
}
