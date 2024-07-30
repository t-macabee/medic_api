namespace Medic.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string LastLogin { get; set; } = string.Empty;
        public int Orders { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public RolesDto Role { get; set; }
    }
}
