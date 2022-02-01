﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class MockRepository : IRepository
    {
        private IEnumerable<UserDTO> _users;
        private IEnumerable<ProjectDTO> _projects;
        private IEnumerable<TicketStatusDTO> _ticketStatuses;
        private IEnumerable<TicketDTO> _tickets;
        private IEnumerable<TicketCommentDTO> _ticketComments;
        public MockRepository()
        {
            _users = new List<UserDTO>() {
                new UserDTO(1, "admin@email.com", "Rinat Saitov", "123456", "9164567561", UserRole.Administrator, 1),
                new UserDTO(2, "first@email.com", "Fernando Alonso", "123456", "9164567561", UserRole.Executor, 1),
                new UserDTO(3, "first@email.com", "Lewis Hamilton", "123456", "9164567561", UserRole.Executor, 1),
                new UserDTO(4, "first@email.com", "Kimi Raikkonen", "123456", "9164567561", UserRole.User, 1),
                new UserDTO(5, "first@email.com", "Max Verstappen", "123456", "9164567561", UserRole.User, 1),
            };

            _projects = new List<ProjectDTO>() {
                new ProjectDTO(1, "Mercedes"),
                new ProjectDTO(2, "Red Bull"),
                new ProjectDTO(3, "Ferrari"),
            };

            _ticketStatuses = new List<TicketStatusDTO>() {
                new TicketStatusDTO(1, "New"),
                new TicketStatusDTO(2, "In progress"),
                new TicketStatusDTO(3, "Delayed"),
                new TicketStatusDTO(4, "Solved"),
            };

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

            _ticketComments = new List<TicketCommentDTO>() {
                new TicketCommentDTO(1, 1, yesterday, "This is first comment"),
                new TicketCommentDTO(2, 1, yesterday, "This is second comment"),
                new TicketCommentDTO(3, 1, today, "This is third comment"),
                new TicketCommentDTO(4, 1, today, "This is fourth comment"),
            };

            _tickets.First().Author = _users.First(x => x.Role == UserRole.User);
            _tickets.First().Executor = _users.First(x => x.Role == UserRole.Executor);
            _tickets.First().Project = _projects.First();
            _tickets.First().Status = _ticketStatuses.First();
            _tickets.First().Comments = _ticketComments.ToList();
        }

        public IEnumerable<UserDTO> SelectUsers() => _users;
        public IEnumerable<ProjectDTO> SelectProjects() => _projects;
        public IEnumerable<TicketStatusDTO> SelectTicketStatuses() => _ticketStatuses;
        public IEnumerable<TicketDTO> SelectTickets()=> _tickets;
        public IEnumerable<TicketCommentDTO> SelectTicketComments() => _ticketComments;
    }    
}
