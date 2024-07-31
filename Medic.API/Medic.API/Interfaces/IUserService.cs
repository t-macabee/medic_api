using Medic.API.Models;
using Medic.API.Models.DTOs;

namespace Medic.API.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UsersDto>> GetAllUsers();
        Task<UsersDto> GetUserDetails(int id);
        Task<UsersDto> EditUser(int id, UserEditDto userEdit);
        Task ToggleUserStatus(int id);
    }
}
