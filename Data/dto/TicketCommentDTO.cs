using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class TicketCommentDTO
    {
        public int Id { get; }
        public int TicketId { get; }
        public DateTime PublishDate { get; }
        public string Comment { get;  }

        public TicketCommentDTO(int id, int ticketId, DateTime publishDate, string comment)
        {
            Id = id;
            TicketId = ticketId;
            PublishDate = publishDate;
            Comment = comment;
        }
    }
}
