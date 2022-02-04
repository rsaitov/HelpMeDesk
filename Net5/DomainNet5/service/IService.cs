using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.service
{
    public interface IService
    {
        IEnumerable<TicketDTO> GetAllTickets();
        TicketDTO GetTicket(int id);
        TicketDTO AddTicket(TicketDTO ticket);
        TicketDTO EditTicket(TicketDTO ticket);
    }
}
