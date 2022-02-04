﻿using Microsoft.EntityFrameworkCore;
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

        public new async Task<List<TicketDTO>> GetAll()
        {
            return await _context.Ticket
                .Include(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Executor)
                .Include(x => x.Status)
                .Include(x => x.Comments)
                .ToListAsync();
        }
        public new async Task<TicketDTO> Get(int id)
        {
            return await _context.Ticket
                .Include(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Executor)
                .Include(x => x.Status)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}