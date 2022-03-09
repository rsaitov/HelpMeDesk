using System.Collections.Generic;

namespace Data
{
    public interface IRepositoryUser
    {
        IEnumerable<UserDTO> SelectAll();
        UserDTO Select(int id);
        UserDTO Insert(UserDTO user);
        UserDTO Update(UserDTO user);

        UserDTO SelectByEmail(string email, string password = null);
        bool Exists(string email);
    }

    public interface IRepositoryProject
    {
        IEnumerable<ProjectDTO> SelectAll();
        ProjectDTO Select(int id);
        ProjectDTO Insert(ProjectDTO project);
        ProjectDTO Update(ProjectDTO project);
    }

    public interface IRepositoryTicket
    {
        IEnumerable<TicketDTO> SelectAll();
        TicketDTO Select(int id);
        TicketDTO Insert(TicketDTO ticket);
        TicketDTO Update(TicketDTO ticket);
    }   

    public interface IRepositoryTicketStatus
    {
        IEnumerable<TicketStatusDTO> SelectAll();
        TicketStatusDTO Select(int id);
        TicketStatusDTO Insert(TicketStatusDTO ticketStatus);
        TicketStatusDTO Update(TicketStatusDTO ticketStatus);
    }
    
    public interface IRepositoryTicketComment
    {
        IEnumerable<TicketCommentDTO> SelectAll();
        TicketCommentDTO Select(int id);
        TicketCommentDTO Insert(TicketCommentDTO ticketComment);
        TicketCommentDTO Update(TicketCommentDTO ticketComment);
    }
}
