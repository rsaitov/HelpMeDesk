using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EFRepositoryTicketComment : IRepositoryTicketComment
    {
        private readonly HelpMeDeskContext _context;
        public EFRepositoryTicketComment(HelpMeDeskContext context)
        {
            _context = context;
        }

        public List<TicketCommentDTO> SelectAll()
        {
            return _context.TicketComment
                .ToList();
        }

        public TicketCommentDTO Select(int id)
        {
            return _context.TicketComment
                .FirstOrDefault(x => x.Id == id);
        }
        public TicketCommentDTO Insert(TicketCommentDTO ticketComment)
        {
            _context.TicketComment.Add(ticketComment);
            _context.SaveChanges();
            return ticketComment;
        }

        public TicketCommentDTO Update(TicketCommentDTO ticketComment)
        {
            _context.Entry(ticketComment).State = EntityState.Modified;
            _context.SaveChanges();
            return ticketComment;
        }
    }
}
