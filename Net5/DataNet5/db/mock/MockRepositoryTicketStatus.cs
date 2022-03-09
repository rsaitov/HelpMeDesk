using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MockRepositoryTicketStatus : IRepositoryTicketStatus
    {
        private List<TicketStatusDTO> _ticketStatuses;
        public MockRepositoryTicketStatus()
        {
            _ticketStatuses = new List<TicketStatusDTO>() {
                new TicketStatusDTO("New"),
                new TicketStatusDTO("In progress"),
                new TicketStatusDTO("Delayed"),
                new TicketStatusDTO("Solved"),
            };
        }
        
        public IEnumerable<TicketStatusDTO> SelectAll()
        {
            return _ticketStatuses;
        }
        public TicketStatusDTO Select(int id)
        {
            return _ticketStatuses.FirstOrDefault(x => x.Id == id);
        }
        public TicketStatusDTO Insert(TicketStatusDTO ticketStatus)
        {
            ticketStatus.Id = _ticketStatuses.Max(x => x.Id) + 1;
            _ticketStatuses.Add(ticketStatus);
            return ticketStatus;
        }
        public TicketStatusDTO Update(TicketStatusDTO ticketStatus)
        {
            return ticketStatus;
        }
    }
}
