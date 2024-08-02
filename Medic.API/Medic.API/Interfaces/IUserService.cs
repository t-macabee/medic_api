using Medic.API.DTOs;
using Medic.API.Models;

namespace Medic.API.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> EditUser(int id, UserEditDto userEdit);
        Task ToggleUserStatus(int id);

    }
}
