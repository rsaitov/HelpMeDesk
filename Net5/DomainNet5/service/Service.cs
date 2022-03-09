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
        private IRepositoryProject _projectRepository;
        private IRepositoryUser _userRepository;
        private IRepositoryTicketComment _ticketCommentRepository;
        private IRepositoryTicketStatus _ticketStatusRepository;
        private IRepositoryTicket _ticketRepository;

        public Service(
            IRepositoryProject projectRepository,
            IRepositoryUser userRepository,
            IRepositoryTicketComment ticketCommentRepository,
            IRepositoryTicketStatus ticketStatusRepository,
            IRepositoryTicket ticketRepository)
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
            return _ticketRepository.Insert(ticket);
        }

        public TicketDTO EditTicket(TicketDTO ticket)
        {
            ticket.LastChangedDate = DateTime.Now;
            return _ticketRepository.Update(ticket);
        }
        public TicketCommentDTO AddTicketComment(TicketCommentDTO comment, string userEmail)
        {
            if (!HaveAccessToComment(comment.ticket, userEmail))
                return null;

            return _ticketCommentRepository.Insert(comment);
        }
        public bool HaveAccessToComment(TicketDTO ticket, string userEmail)
        {
            if (ticket == null)
                return false;

            var user = GetUser(userEmail);
            if (user == null)
                return false;

            if (user.Role == UserRole.Executor ||
                user.Role == UserRole.Administrator ||
                user.Id == ticket.AuthorId)
                return true;

            return false;
        }

        public TicketDTO GetTicket(int id)
        {
            return _ticketRepository.Select(id);
        }
        public IEnumerable<TicketDTO> GetAllTickets()
        {
            return _ticketRepository.SelectAll();
        }

        public IEnumerable<TicketStatusDTO> GetAllTicketStatuses()
        {
            return _ticketStatusRepository.SelectAll();
        }

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            return _projectRepository.SelectAll();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userRepository.SelectAll();
        }

        public ProjectDTO GetProject(int id)
        {
            return _projectRepository.Select(id);
        }

        public bool CheckUserExists(string email)
        {
            return _userRepository.Exists(email);
        }
        public UserDTO GetUser(string email)
        {
            return _userRepository.SelectByEmail(email);
        }
        public UserDTO GetUser(int id)
        {
            return _userRepository.Select(id);
        }
        public UserDTO CheckUser(string email, string password)
        {
            return _userRepository.SelectByEmail(email, password);
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

            _userRepository.Insert(user);
        }
    }
}
