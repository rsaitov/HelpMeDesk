using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.ViewModels
{
    public class TicketListViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
