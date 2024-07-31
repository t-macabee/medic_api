using Mapster;
using MapsterMapper;
using Medic.API.Data;
using Medic.API.Helpers;
using Medic.API.Interfaces;
using Medic.API.Models;
using Medic.API.Models.DTOs;
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

        public async Task<IEnumerable<UsersDto>> GetAllUsers()
        {
            var users = await context.Users.Include(x => x.Role).ToListAsync();
            return mapper.Map<IEnumerable<UsersDto>>(users);
        }

        public async Task<UsersDto> GetUserDetails(int id)
        {
            var user = await context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            return mapper.Map<UsersDto>(user);
        }

        public async Task<UsersDto> EditUser(int id, UserEditDto userEdit)
        {
            var user = await context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user = userEdit.Adapt(user);

            await context.SaveChangesAsync();

            return mapper.Map<UsersDto>(user);
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
