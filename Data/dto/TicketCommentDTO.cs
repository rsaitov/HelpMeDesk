using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class TicketCommentDTO
    {
        public int Id { get; set; }
        public TicketDTO Ticket { get; set; }
        public DateTime PublishDate { get; set; }

        public string Comment { get; set; }
    }
}
