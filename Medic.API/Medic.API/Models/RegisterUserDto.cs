namespace Medic.API.Models
{
    public class RegisterUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Orders { get; set; }        
    }
}
