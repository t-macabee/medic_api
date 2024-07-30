using MapsterMapper;
using Medic.API.Data;
using Medic.API.Entities;
using Medic.API.Helpers;
using Medic.API.Interfaces;
using Medic.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Services
{
    public class UserService : IUserService
    {
        private DataContext Context { get; set; } 
        private IMapper Mapper { get; set; } 

        public UserService(DataContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }        

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await Context.Users.Include(x => x.Role).ToListAsync();
            return Mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserDetails(int id)
        {
            var user = await Context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return Mapper.Map<UserDto>(user);
        }

        public async Task RegisterUser(RegisterUserDto registerUser)
        {
            var existingUser = await Context.Users.FirstOrDefaultAsync(x => x.Username == registerUser.Username);

            if (existingUser != null) 
            {
                throw new InvalidOperationException("A user with this username already exists.");
            }

            var newUser = Mapper.Map<User>(registerUser);

            newUser.PasswordSalt = PasswordBuilder.GenerateSalt();
            newUser.PasswordHash = PasswordBuilder.GenerateHash(newUser.PasswordSalt, registerUser.Password);

            await Context.Users.AddAsync(newUser);
            await Context.SaveChangesAsync();
        }

        public async Task BlockUser(int id)
        {
            var user = await Context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user.Status = "Blocked";

            Context.Users.Update(user);

            await Context.SaveChangesAsync();
        }
    }
}
