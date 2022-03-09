using System.Collections.Generic;

namespace Data
{
    public interface IRepositoryUser
    {
        List<UserDTO> SelectAll();
        UserDTO Select(int id);
        UserDTO Insert(UserDTO user);
        UserDTO Update(UserDTO user);

        UserDTO SelectByEmail(string email, string password = null);
        bool Exists(string email);
    }

    public interface IRepositoryProject
    {
        List<ProjectDTO> SelectAll();
        ProjectDTO Select(int id);
        ProjectDTO Insert(ProjectDTO project);
        ProjectDTO Update(ProjectDTO project);
    }

    public interface IRepositoryTicket
    {
        List<TicketDTO> SelectAll();
        TicketDTO Select(int id);
        TicketDTO Insert(TicketDTO ticket);
        TicketDTO Update(TicketDTO ticket);
    }   

    public interface IRepositoryTicketStatus
    {
        List<TicketStatusDTO> SelectAll();
        TicketStatusDTO Select(int id);
        TicketStatusDTO Insert(TicketStatusDTO ticketStatus);
        TicketStatusDTO Update(TicketStatusDTO ticketStatus);
    }
    
    public interface IRepositoryTicketComment
    {
        List<TicketCommentDTO> SelectAll();
        TicketCommentDTO Select(int id);
        TicketCommentDTO Insert(TicketCommentDTO ticketStatus);
        TicketCommentDTO Update(TicketCommentDTO ticketStatus);
    }
}
