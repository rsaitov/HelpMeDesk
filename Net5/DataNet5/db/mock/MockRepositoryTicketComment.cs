using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MockRepositoryTicketComment : IRepositoryTicketComment
    {
        private List<TicketCommentDTO> _ticketComments;
        public MockRepositoryTicketComment()
        {
            var today = DateTime.Now;
            var yesterday = today.AddDays(-1);

            _ticketComments = new List<TicketCommentDTO>() {
                new TicketCommentDTO(1, yesterday, "This is first comment", authorId: 1),
                new TicketCommentDTO(1, yesterday, "This is second comment", authorId: 1),
                new TicketCommentDTO(1, today, "This is third comment", authorId: 1),
                new TicketCommentDTO(1, today, "This is fourth comment", authorId: 1),
            };
        }
        public IEnumerable<TicketCommentDTO> SelectAll()
        {
            return _ticketComments;
        }
        public TicketCommentDTO Select(int id)
        {
            return _ticketComments.FirstOrDefault(x => x.Id == id);
        }
        public TicketCommentDTO Insert(TicketCommentDTO ticketComment)
        {
            ticketComment.Id = _ticketComments.Max(x => x.Id) + 1;
            _ticketComments.Add(ticketComment);
            return ticketComment;
        }
        public TicketCommentDTO Update(TicketCommentDTO ticketComment)
        {
            return ticketComment;
        }
    }
}
