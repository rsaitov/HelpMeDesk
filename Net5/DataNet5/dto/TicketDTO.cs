using System;
using System.Collections.Generic;

namespace Data
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual ProjectDTO Project { get; set; }
        public int AuthorId { get; set; }
        public virtual UserDTO Author { get; set; }
        //public List<UserDTO> Executors{ get;  }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangedDate { get; set; }
        public int StatusId { get; set; }
        public virtual TicketStatusDTO Status { get; set; }
        public TicketOrigin Origin { get; set; }
        public TicketPriority Priority { get; set; }
        public int ExecutorId { get; set; }
        public virtual UserDTO Executor { get; set; }
        public List<TicketCommentDTO> Comments { get; set; }

        public TicketDTO(int id, int projectId, int authorId, string name, string description,
            DateTime creationDate, DateTime lastChangedDate, int statusId, TicketOrigin origin, TicketPriority priority, 
            int executorId)
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
            Priority = priority;
            ExecutorId = executorId;
        }

        public TicketDTO()
        {

        }

    }
}
