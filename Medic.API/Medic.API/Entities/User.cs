namespace Medic.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public int Orders { get; set; }
        public string ImageUrl { get; set; } 
        public string Status { get; set; } 

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; } 

        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}
