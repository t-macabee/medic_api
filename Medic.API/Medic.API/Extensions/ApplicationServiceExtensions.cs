using Mapster;
using Medic.API.Data;
using Medic.API.Helpers;
using Medic.API.Interfaces;
using Medic.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITokenService, TokenService>();            
            services.AddScoped<IPhotoService, PhotoService>();            
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

            services.AddMapster();
            MapsterConfiguration.RegisterMappings();

            return services;
        }
    }
}
