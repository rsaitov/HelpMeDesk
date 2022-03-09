using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EFRepositoryTicketStatus : IRepositoryTicketStatus
    {
        private readonly HelpMeDeskContext _context;
        public EFRepositoryTicketStatus(HelpMeDeskContext context)
        {
            _context = context;
        }

        public List<TicketStatusDTO> SelectAll()
        {
            return _context.TicketStatus
                .ToList();
        }

        public TicketStatusDTO Select(int id)
        {
            return _context.TicketStatus
                .FirstOrDefault(x => x.Id == id);
        }
        public TicketStatusDTO Insert(TicketStatusDTO ticketStatus)
        {
            _context.TicketStatus.Add(ticketStatus);
            _context.SaveChanges();
            return ticketStatus;
        }

        public TicketStatusDTO Update(TicketStatusDTO ticketStatus)
        {
            _context.Entry(ticketStatus).State = EntityState.Modified;
            _context.SaveChanges();
            return ticketStatus;
        }
    }
}
