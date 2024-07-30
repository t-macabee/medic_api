using Mapster;
using Medic.API.Entities;
using Medic.API.Models;

namespace Medic.API.Helpers
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Roles, RolesDto>
                .NewConfig()
                .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<User, UserDto>
                .NewConfig();

            TypeAdapterConfig<RegisterUserDto, User>
                .NewConfig()
                .Map(dest => dest.RoleId, src => 2);                 

            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
