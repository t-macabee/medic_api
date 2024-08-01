﻿using Mapster;
using Medic.API.DTOs;
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
                .NewConfig()
                .Map(dest => dest.DateOfBirth, src => src.DateOfBirth.ToString("d"))
                .Map(dest => dest.LastLogin, src => src.LastLogin.ToString("d"));

            TypeAdapterConfig<UserEditDto, User>
                .NewConfig();

            TypeAdapterConfig<RegisterDto, User>
                .NewConfig()
                .Map(dest => dest.RoleId, src => 2);                 

            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
