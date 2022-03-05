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
            var date = DateTime.Now;
            ticket.CreationDate = date;
            ticket.LastChangedDate = date;
            return _ticketRepository.Add(ticket);
        }

        public TicketDTO EditTicket(TicketDTO ticket)
        {
            ticket.LastChangedDate = DateTime.Now;
            return _ticketRepository.Update(ticket);
        }
        public TicketCommentDTO AddTicketComment(TicketCommentDTO comment)
        {
            return _ticketCommentRepository.Add(comment);
        }

        public TicketDTO GetTicket(int id)
        {
            return _ticketRepository.Get(id);
        }
        public IEnumerable<TicketDTO> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        public IEnumerable<TicketStatusDTO> GetAllTicketStatuses()
        {
            return _ticketStatusRepository.GetAll();
        }

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public ProjectDTO GetProject(int id)
        {
            return _projectRepository.Get(id);
        }

        public bool CheckUserExists(string email)
        {
            return _userRepository.Exists(email);
        }
        public UserDTO GetUser(string email)
        {
            return _userRepository.Get(email);
        }
        public UserDTO GetUser(int id)
        {
            return _userRepository.Get(id);
        }
        public UserDTO CheckUser(string email, string password)
        {
            return _userRepository.Get(email, password);
        }

        public void RegisterUser(string email, string name, string password, int projectId)
        {
            if (_userRepository.Exists(email))
                return;

            var user = new UserDTO(
                email.ToLower(), 
                name, 
                password,
                phone: "",
                role: UserRole.User,
                projectId: projectId);

            _userRepository.Add(user);
        }
    }
}
