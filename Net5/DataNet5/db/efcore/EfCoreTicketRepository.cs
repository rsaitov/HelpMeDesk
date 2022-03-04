using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfCoreTicketRepository : EfCoreRepository<TicketDTO, HelpMeDeskContext>
    {
        private readonly HelpMeDeskContext _context;
        public EfCoreTicketRepository(HelpMeDeskContext context) : base(context)
        {
            _context = context;
        }

        public new List<TicketDTO> GetAll()
        {
            return _context.Ticket
                .Include(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Executor)
                .Include(x => x.Status)
                .Include(x => x.Comments)
                .ToList();
        }
        public TicketDTO Get(int id)
        {
            return _context.Ticket
                .Include(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Executor)
                .Include(x => x.Status)
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
