using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MockRepository : IRepository
    {
        private HashSet<UserDTO> _users;
        private HashSet<ProjectDTO> _projects;
        private HashSet<TicketStatusDTO> _ticketStatuses;
        private HashSet<TicketDTO> _tickets;
        private HashSet<TicketCommentDTO> _ticketComments;
        public MockRepository()
        {
            _users = new HashSet<UserDTO>() {
                new UserDTO(1, "admin@email.com", "Rinat Saitov", "123456", "9164567561", UserRole.Administrator, 1),
                new UserDTO(2, "first@email.com", "Fernando Alonso", "123456", "9164567561", UserRole.Executor, 1),
                new UserDTO(3, "first@email.com", "Lewis Hamilton", "123456", "9164567561", UserRole.Executor, 1),
                new UserDTO(4, "first@email.com", "Kimi Raikkonen", "123456", "9164567561", UserRole.User, 1),
                new UserDTO(5, "first@email.com", "Max Verstappen", "123456", "9164567561", UserRole.User, 1),
            };

            _projects = new HashSet<ProjectDTO>() {
                new ProjectDTO(1, "Mercedes"),
                new ProjectDTO(2, "Red Bull"),
                new ProjectDTO(3, "Ferrari"),
            };

            _ticketStatuses = new HashSet<TicketStatusDTO>() {
                new TicketStatusDTO(1, "New"),
                new TicketStatusDTO(2, "In progress"),
                new TicketStatusDTO(3, "Delayed"),
                new TicketStatusDTO(4, "Solved"),
            };

            var today = DateTime.Now.Date;
            var yesterday = today.AddDays(-1);

            _tickets = new HashSet<TicketDTO>() {
                new TicketDTO(1, 1, 4, "Server not works", "This is the description", yesterday, today, 1, TicketOrigin.Web),
                new TicketDTO(2, 1, 4, "Application not works", "This is the description", yesterday, today, 2, TicketOrigin.Web),
                new TicketDTO(3, 1, 5, "Printer HP not works", "This is the description", yesterday, today, 3, TicketOrigin.Web),
                new TicketDTO(4, 1, 5, "Server not works", "This is the description", yesterday, today, 4, TicketOrigin.Web),
            };

            _ticketComments = new HashSet<TicketCommentDTO>() {
                new TicketCommentDTO(1, 1, yesterday, "This is first comment"),
                new TicketCommentDTO(2, 2, yesterday, "This is second comment"),
                new TicketCommentDTO(3, 3, today, "This is third comment"),
                new TicketCommentDTO(4, 4, today, "This is fourth comment"),
            };
        }

        public HashSet<UserDTO> SelectUsers() => _users;
        public HashSet<ProjectDTO> SelectProjects() => _projects;
        public HashSet<TicketStatusDTO> SelectTicketStatuses() => _ticketStatuses;
        public HashSet<TicketDTO> SelectTickets()=> _tickets;
        public HashSet<TicketCommentDTO> SelectTicketComments() => _ticketComments;
    }
}
