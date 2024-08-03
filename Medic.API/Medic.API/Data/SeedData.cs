using Medic.API.Entities;
using Medic.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedUsers(builder);
        }

        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Roles>().HasData(
                new Roles { Id = 1, Name = "Administrator" },
                new Roles { Id = 2, Name = "Employee" }
            );
        }

        public static void SeedUsers(ModelBuilder builder)
        {
            var adminSalt = PasswordBuilder.GenerateSalt();
            var adminHash = PasswordBuilder.GenerateHash(adminSalt, "admin");

            var employeeSalt = PasswordBuilder.GenerateSalt();
            var employeeHash = PasswordBuilder.GenerateHash(employeeSalt, "employee");

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "John Doe",
                    Username = "admin",
                    PasswordHash = adminHash,
                    PasswordSalt = adminSalt,
                    RoleId = 1,
                    DateOfBirth = new DateTime(1996, 7, 29),
                    LastLogin = DateTime.Now,
                    Orders = 0,
                    Status = "Active",
                    PhotoUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRDII-r7EXoUFaBaDk0RdiqbtUf6RCG_uE-J4XJULl6OEvObd97"

                }             
            );
        }        
    }
}