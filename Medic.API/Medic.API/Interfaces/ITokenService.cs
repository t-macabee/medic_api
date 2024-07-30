using Medic.API.Entities;

namespace Medic.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
