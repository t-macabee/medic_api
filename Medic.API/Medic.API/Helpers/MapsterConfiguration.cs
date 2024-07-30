using Mapster;
using Medic.API.Entities;
using Medic.API.Models;
using Medic.API.Models.DTOs;

namespace Medic.API.Helpers
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Roles, RolesDto>
                .NewConfig()
                .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<User, UsersDto>
                .NewConfig();
               
            TypeAdapterConfig<UserEditDto, User>
                .NewConfig();

            TypeAdapterConfig<RegisterDto, User>
                .NewConfig()
                .Map(dest => dest.RoleId, src => 2);                 

            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
