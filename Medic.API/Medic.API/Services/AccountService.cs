using MapsterMapper;
using Medic.API.Data;
using Medic.API.DTOs;
using Medic.API.Entities;
using Medic.API.Helpers;
using Medic.API.Interfaces;
using Medic.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Services
{
    public class AccountService : IAccountService
    {
        private DataContext context { get; set; }
        private IMapper mapper { get; set; }

        private readonly ITokenService tokenService;

        public AccountService(DataContext context, IMapper mapper, ITokenService tokenService)
        {
            this.context = context;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<UserDto> Login(LoginDto login)
        {
            if (string.IsNullOrWhiteSpace(login.Username) || string.IsNullOrWhiteSpace(login.Password))
            {
                throw new Exception("Username and password are required.");
            }

            var user = await context.Users.Include(x => x.Role).SingleOrDefaultAsync(y => y.Username == login.Username);
           
            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            if (user.Status == "Blocked")
            {
                throw new Exception("User profile has beed blocked.");
            }

            if (!PasswordBuilder.VerifyPassword(user.PasswordSalt, login.Password, user.PasswordHash))
            {
                throw new Exception("Invalid username or password.");
            }            

            if (user.Role.Name != "Administrator")
            {
                throw new Exception("Insufficient credentials. Only administrator can log in.");
            }           

            user.LastLogin = DateTime.UtcNow;
            await context.SaveChangesAsync();

            var token = tokenService.CreateToken(user);
            var entity = mapper.Map<UserDto>(user);
            entity.Token = token;

            return entity;
        }

        public async Task<UserDto> Register(RegisterDto registerUser)
        {
            if (await UserExists(registerUser.Username))
            {
                throw new Exception("Username is already taken!");
            }

            int nextOrder = await context.Users.OrderByDescending(x => x.Orders).Select(y => y.Orders).FirstOrDefaultAsync() + 1;

            if (nextOrder > 10)
            {
                throw new InvalidOperationException("Maximum number of orders reached.");
            }            

            var newUser = mapper.Map<User>(registerUser);

            newUser.PasswordSalt = PasswordBuilder.GenerateSalt();
            newUser.PasswordHash = PasswordBuilder.GenerateHash(newUser.PasswordSalt, registerUser.Password);
            newUser.Orders = nextOrder;
            newUser.Status = "Active";            

            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            var token = tokenService.CreateToken(newUser);

            var user = await context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Id == newUser.Id);

            var entity = mapper.Map<UserDto>(user);

            entity.Token = token;

            return entity;
        }        

        private async Task<bool> UserExists(string username)
        {
            return await context.Users.AnyAsync(x => x.Username == username.ToLower());
        }        
    }
}

