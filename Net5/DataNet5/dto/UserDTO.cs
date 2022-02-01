using System.Collections.Generic;

namespace Data
{
    public class UserDTO
    {
        public int Id { get; }
        public string Email { get; }
        public string Name { get; }
        public string Password { get; }
        public string Phone { get; }
        public UserRole Role { get; }
        public int ProjectId { get; }

        public UserDTO(int id, string email, string name, string password, string phone, UserRole role, int projectId)
        {
            Id = id;
            Email = email;
            Name = name;
            Password = password;
            Phone = phone;
            Role = role;
            ProjectId = projectId;
        }
    }
}
