using System.Collections.Generic;

namespace Data
{
    public interface IRepository
    {
        HashSet<UserDTO> SelectUsers();
        //UserDTO InsertUser(UserDTO user);
        //bool UpdateUser(UserDTO user);
        //bool DeleteUser(int userId);

        HashSet<ProjectDTO> SelectProjects();
        HashSet<TicketStatusDTO> SelectTicketStatuses();
        HashSet<TicketDTO> SelectTickets();
        HashSet<TicketCommentDTO> SelectTicketComments();
    }
}
