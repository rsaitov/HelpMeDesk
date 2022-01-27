using System.Collections.Generic;

namespace Data
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public List<ProjectDTO> Projects { get; set; }
    }
}
