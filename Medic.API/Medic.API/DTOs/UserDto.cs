using Medic.API.DTOs;

namespace Medic.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Token { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
