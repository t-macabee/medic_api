using Medic.API.Models;

namespace Medic.API.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserDetails(int id);
        Task RegisterUser(RegisterUserDto registerUser);
        Task BlockUser(int id);
    }
}
