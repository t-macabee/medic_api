using Medic.API.Entities;
using Medic.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                new User { Id = 1, Name = "John Doe", Username = "admin", PasswordHash = adminHash, PasswordSalt = adminSalt, RoleId = 1, DateOfBirth = new DateTime(1996, 7, 29), LastLogin = DateTime.Now, Orders = 0, ImageUrl = "https://randomuser.me/api/portraits/men/23.jpg", Status = "Active" },
                new User { Id = 2, Name = "Jane Doe", Username = "janedoe", PasswordHash = employeeHash, PasswordSalt = employeeSalt, RoleId = 2, DateOfBirth = new DateTime(1997, 6, 15), LastLogin = DateTime.Now, Orders = 1, ImageUrl = "https://randomuser.me/api/portraits/women/39.jpg", Status = "Active" }
            );
        }
    }
}
