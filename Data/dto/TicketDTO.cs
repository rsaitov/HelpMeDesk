using System;
using System.Collections.Generic;

namespace Data
{
    public class TicketDTO
    {
        public int Id { get; }
        public int ProjectId { get; }
        public int AuthorId { get; }
        //public List<UserDTO> Executors{ get;  }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreationDate { get; }
        public DateTime LastChangedDate { get; }
        public int StatusId { get; }
        public TicketOrigin Origin { get; }
        //public List<TicketCommentDTO> Comments { get;  }

        public TicketDTO(int id, int projectId, int authorId, string name, string description,
            DateTime creationDate, DateTime lastChangedDate, int statusId, TicketOrigin origin)
        {
            Id = id;
            ProjectId = projectId;
            AuthorId = authorId;
            Name = name;
            Description = description;
            CreationDate = creationDate;
            LastChangedDate = lastChangedDate;
            StatusId = statusId;
            Origin = origin;
        }

    }
}
