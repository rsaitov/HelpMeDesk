using System.Collections.Generic;

namespace Data
{
    public class UserDTO : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRole Role { get; set; }
        public int ProjectId { get; set; }
        public virtual ProjectDTO Project { get; set; }

        public UserDTO(string email, string name, string password, string phone, UserRole role, int projectId)
        {
            Email = email;
            Name = name;
            Password = password;
            Phone = phone;
            Role = role;
            ProjectId = projectId;
        }
        public UserDTO(int id, string email, string name, string password, string phone, UserRole role, int projectId) 
            : this(email, name, password, phone, role, projectId)
        {
            Id = id;
        }
    }
}
