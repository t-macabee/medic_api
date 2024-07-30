using Medic.API.Models.DTOs;

namespace Medic.API.Interfaces
{
    public interface IAccountService
    {
        Task<AuthResponseDto> Register(RegisterDto registerUser);
        Task<AuthResponseDto> Login(LoginDto login);
    }
}
