using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MockRepositoryTicket : IRepositoryTicket
    {
        private List<TicketDTO> _tickets;
        public MockRepositoryTicket()
        {
            var today = DateTime.Now;
            var yesterday = today.AddDays(-1);

            string longDescription = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Nulla aliquet enim tortor at auctor urna. Diam volutpat commodo sed egestas. 
Enim blandit volutpat maecenas volutpat blandit aliquam etiam erat velit. 
Eu nisl nunc mi ipsum faucibus vitae aliquet nec. Ut venenatis tellus in metus vulputate eu scelerisque. 
Malesuada fames ac turpis egestas. Faucibus scelerisque eleifend donec pretium vulputate. 
Tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi. ";

            _tickets = new List<TicketDTO>() {
                new TicketDTO(1, 1, 4, "Server not works", longDescription, yesterday, today, 1, TicketOrigin.Web, TicketPriority.Low, 2),
                new TicketDTO(2, 1, 4, "Application not works", "This is the description", yesterday, today, 2, TicketOrigin.Web, TicketPriority.Medium, 2),
                new TicketDTO(3, 1, 5, "Printer HP not works", "This is the description", yesterday, today, 3, TicketOrigin.Web, TicketPriority.High, 3),
                new TicketDTO(4, 1, 5, "Server not works", "This is the description", yesterday, today, 4, TicketOrigin.Web, TicketPriority.Critical, 3),
            };
        }
        public IEnumerable<TicketDTO> SelectAll()
        {
            return _tickets;
        }
        public TicketDTO Select(int id)
        {
            return _tickets.FirstOrDefault(x => x.Id == id);
        }
        public TicketDTO Insert(TicketDTO ticket)
        {
            ticket.Id = _tickets.Max(x => x.Id) + 1;
            _tickets.Add(ticket);
            return ticket;
        }
        public TicketDTO Update(TicketDTO ticket)
        {
            return ticket;
        }
    }
}
