using System.Collections.Generic;

namespace Data
{
    public interface IRepository
    {
        IEnumerable<UserDTO> SelectUsers();
        //UserDTO InsertUser(UserDTO user);
        //bool UpdateUser(UserDTO user);
        //bool DeleteUser(int userId);

        IEnumerable<ProjectDTO> SelectProjects();
        IEnumerable<TicketStatusDTO> SelectTicketStatuses();
        IEnumerable<TicketDTO> SelectTickets();
        IEnumerable<TicketCommentDTO> SelectTicketComments();

        bool InsertTicket(TicketDTO ticket);
        bool UpdateTicket(TicketDTO ticket);
    }
}
