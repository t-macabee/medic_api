using MapsterMapper;
using Medic.API.Data;
using Medic.API.DTOs;
using Medic.API.Entities;
using Medic.API.Interfaces;
using Medic.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Services
{
    public class UserService(DataContext context, IMapper mapper) : IUserService
    {
        private DataContext context { get; set; } = context;
        private IMapper mapper { get; set; } = mapper;

        public async Task<IEnumerable<MemberDto>> GetAllUsers()
        {
            var users = await context.Users.Include(x => x.Role).Include(x => x.Photos).ToListAsync();

            return mapper.Map<IEnumerable<MemberDto>>(users);
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.Include(x => x.Role).Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("User not found.");
        }

        public async Task<MemberDto> EditUser(int id, MemberEditDto userEdit)
        {
            var user = await context.Users.Include(x => x.Role).Include(x => x.Photos).SingleOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("User not found.");

            if (user.Username != userEdit.Username && await context.Users.AnyAsync(x => x.Username == userEdit.Username))
            {
                throw new Exception("Username is already taken.");
            }

            if (!string.IsNullOrEmpty(userEdit.Name))
            {
                user.Name = userEdit.Name;
            }
            if (!string.IsNullOrEmpty(userEdit.Username))
            {
                user.Username = userEdit.Username;
            }
            if (!string.IsNullOrEmpty(userEdit.Status))
            {
                user.Status = userEdit.Status;
            }

            await context.SaveChangesAsync();

            return mapper.Map<MemberDto>(user);
        }

        public async Task ToggleUserStatus(int id)
        {
            var user = await context.Users.FindAsync(id) ?? throw new KeyNotFoundException("User not found.");

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
