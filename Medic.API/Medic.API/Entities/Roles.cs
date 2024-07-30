namespace Medic.API.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = [];
    }
}
