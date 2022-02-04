using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.service
{
    public class Service : IService
    {
        private IRepository<TicketDTO> _repository;
        public Service(IRepository<TicketDTO> repository)
        {
            _repository = repository;
        }

        public bool AddTicket<TicketDTO>(TicketDTO ticket)
        {
            return true;
        }

        public bool AddTicket(TicketDTO ticket)
        {
            throw new NotImplementedException();
        }

        public bool EditTicket(TicketDTO ticket)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketDTO> GetAllTickets()
        {
            return null;
        }
    }
}
