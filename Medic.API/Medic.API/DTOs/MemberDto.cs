using Medic.API.Models;

namespace Medic.API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string? PhotoUrl { get; set; }
        public string LastLogin { get; set; }
        public int Orders { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }
        public RolesDto Role { get; set; }
        public List<PhotoDto> Photos { get; set; }
    }
}
