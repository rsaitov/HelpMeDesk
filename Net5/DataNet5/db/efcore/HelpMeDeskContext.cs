using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HelpMeDeskContext : DbContext
    {
        public HelpMeDeskContext(DbContextOptions<HelpMeDeskContext> options) : base(options)
        {
        }

        public DbSet<ProjectDTO> Project { get; set; }
        public DbSet<UserDTO> User { get; set; }
        public DbSet<TicketDTO> Ticket { get; set; }
        public DbSet<TicketStatusDTO> TicketStatus { get; set; }
        public DbSet<TicketCommentDTO> TicketComment { get; set; }
    }
}
