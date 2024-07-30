namespace Medic.API.Models.DTOs
{
    public class AuthResponseDto
    {
        public UsersDto User { get; set; } 
        public string Token { get; set; }
    }
}
