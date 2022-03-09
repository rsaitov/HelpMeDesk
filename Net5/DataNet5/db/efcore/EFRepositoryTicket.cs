using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EFRepositoryTicket : IRepositoryTicket
    {
        private readonly HelpMeDeskContext _context;
        public EFRepositoryTicket(HelpMeDeskContext context)
        {
            _context = context;
        }

        public IEnumerable<TicketDTO> SelectAll()
        {
            return _context.Ticket
                .Include(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Executor)
                .Include(x => x.Status)
                .Include(x => x.Comments)
                .ToList();
        }

        public TicketDTO Select(int id)
        {
            return _context.Ticket
                .Include(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Executor)
                .Include(x => x.Status)
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id == id);
        }
        public TicketDTO Insert(TicketDTO ticket)
        {
            _context.Ticket.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public TicketDTO Update(TicketDTO ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
            _context.SaveChanges();
            return ticket;
        }
    }
}
