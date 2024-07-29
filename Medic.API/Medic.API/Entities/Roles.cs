namespace Medic.API.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Users> Users { get; set; } = [];
    }
}
