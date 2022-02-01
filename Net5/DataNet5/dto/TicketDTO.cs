using System;
using System.Collections.Generic;

namespace Data
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int AuthorId { get; set; }
        //public List<UserDTO> Executors{ get;  }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangedDate { get; set; }
        public int StatusId { get; set; }
        public TicketOrigin Origin { get; set; }
        public int ExecutorId { get; set; }
        //public List<TicketCommentDTO> Comments { get;  }

        public TicketDTO(int id, int projectId, int authorId, string name, string description,
            DateTime creationDate, DateTime lastChangedDate, int statusId, TicketOrigin origin, int executorId)
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
            ExecutorId = executorId;
        }

        public TicketDTO()
        {

        }

    }
}
