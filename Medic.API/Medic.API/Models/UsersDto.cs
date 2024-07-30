namespace Medic.API.Models
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string LastLogin { get; set; }
        public int Orders { get; set; }
        public string ImageUrl { get; set; } 
        public string Status { get; set; }
        public string Username { get; set; } 
        public RolesDto Role { get; set; }
    }
}
