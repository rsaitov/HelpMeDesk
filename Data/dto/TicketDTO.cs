using System;
using System.Collections.Generic;

namespace Data
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public ProjectDTO Project { get; set; }
        public UserDTO Author { get; set; }
        public List<UserDTO> Executors{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangedDate { get; set; }
        public TicketOrigin Origin { get; set; }
        public List<TicketCommentDTO> Comments { get; set; }

    }
}
