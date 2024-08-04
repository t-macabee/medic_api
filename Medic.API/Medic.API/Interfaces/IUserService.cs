using CloudinaryDotNet.Actions;
using Medic.API.DTOs;
using Medic.API.Entities;
using Medic.API.Models;

namespace Medic.API.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<MemberDto>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<MemberDto> EditUser(int id, MemberEditDto userEdit);
        Task ToggleUserStatus(int id);
    }
}
