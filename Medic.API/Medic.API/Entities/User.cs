namespace Medic.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime LastLogin { get; set; }
        public int Orders { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}
