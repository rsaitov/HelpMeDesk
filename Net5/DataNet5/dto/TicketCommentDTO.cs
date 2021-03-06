using System;

namespace Data
{
    public class TicketCommentDTO : IEntity
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public virtual TicketDTO ticket { get; set; }
        public DateTime PublishDate { get; set; }
        public string Comment { get; set; }
        public int? AuthorId { get; set; }
        public virtual UserDTO Author { get; set; }

        public TicketCommentDTO(int ticketId, DateTime publishDate, string comment, int? authorId)
        {
            TicketId = ticketId;
            PublishDate = publishDate;
            Comment = comment;
            AuthorId = authorId;
        }
    }
}
