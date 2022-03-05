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

        TicketCommentDTO AddTicketComment(TicketCommentDTO comment);

        IEnumerable<TicketStatusDTO> GetAllTicketStatuses();
        IEnumerable<ProjectDTO> GetAllProjects();
        IEnumerable<UserDTO> GetAllUsers();

        ProjectDTO GetProject(int id);

        bool CheckUserExists(string email);
        UserDTO GetUser(int id);
        UserDTO GetUser(string email);
        UserDTO CheckUser(string email, string password);
        void RegisterUser(string email, string name, string password, int projectId);
    }
}
