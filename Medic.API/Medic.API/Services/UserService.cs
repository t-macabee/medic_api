using Mapster;
using MapsterMapper;
using Medic.API.Data;
using Medic.API.DTOs;
using Medic.API.Helpers;
using Medic.API.Interfaces;
using Medic.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Services
{
    public class UserService : IUserService
    {
        private DataContext context { get; set; }
        private IMapper mapper { get; set; }

        public UserService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await context.Users.Include(x => x.Role).ToListAsync();
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserDetails(int id)
        {
            var user = await context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> EditUser(int id, UserEditDto userEdit)
        {
            var user = await context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user = userEdit.Adapt(user);

            await context.SaveChangesAsync();

            return mapper.Map<UserDto>(user);
        }

        public async Task ToggleUserStatus(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            if (user.Status == "Blocked")
            {
                user.Status = "Active";
            }
            else
            {
                user.Status = "Blocked";
            }

            context.Users.Update(user);

            await context.SaveChangesAsync();
        }

       
    }       
}
