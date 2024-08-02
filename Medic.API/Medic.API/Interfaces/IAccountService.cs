using Medic.API.DTOs;
using Medic.API.Models;

namespace Medic.API.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> Register(RegisterDto registerUser);
        Task<UserDto> Login(LoginDto login);
        Task<int> GetOrderNumber();
    }
}
