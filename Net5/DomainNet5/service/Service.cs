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
        private EfCoreTicketRepository _ticketRepository;
        private EfCoreProjectRepository _projectRepository;
        private EfCoreUserRepository _userRepository;
        private EfCoreTicketCommentRepository _ticketCommentRepository;
        private EfCoreTicketStatusRepository _ticketStatusRepository;

        public Service(
            EfCoreProjectRepository projectRepository,
            EfCoreUserRepository userRepository,
            EfCoreTicketCommentRepository ticketCommentRepository,
            EfCoreTicketStatusRepository ticketStatusRepository,
            EfCoreTicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _ticketCommentRepository = ticketCommentRepository;
            _ticketStatusRepository = ticketStatusRepository;
        }

        public TicketDTO AddTicket(TicketDTO ticket)
        {
            return _ticketRepository.Add(ticket);
        }

        public TicketDTO EditTicket(TicketDTO ticket)
        {
            return _ticketRepository.Update(ticket);
        }
        public TicketDTO GetTicket(int id)
        {
            return _ticketRepository.Get(id);
        }
        public IEnumerable<TicketDTO> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }
    }
}
