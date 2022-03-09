using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SeedData
    {
        private static List<ProjectDTO> _projects = new List<ProjectDTO>
        {

        };
        public static void Initial(HelpMeDeskContext context)
        {
            if (!context.TicketStatus.Any())
            {
                context.TicketStatus.AddRange(
                    new TicketStatusDTO("New"),
                    new TicketStatusDTO("In progress"),
                    new TicketStatusDTO("Delayed"),
                    new TicketStatusDTO("Solved")
                );
            }

            if (!context.Project.Any())
            {
                context.Project.AddRange(
                    new ProjectDTO("Janinn Fitness"),
                    new ProjectDTO("Zebra Fitness Msk"),
                    new ProjectDTO("Zebra Fitness Vlg")
                );
            }

            context.SaveChanges();
            var projectId1 = context.Project.First().Id;
            var ticketStatusId1 = context.TicketStatus.First().Id;

            if (!context.User.Any())
            {
                context.User.AddRange(
                    new UserDTO("admin@email.com", "Rinat Saitov", "123456", "9164567561", UserRole.Administrator, projectId1),
                    new UserDTO("first@email.com", "Fernando Alonso", "123456", "9164567561", UserRole.Executor, projectId1),
                    new UserDTO("sec@email.com", "Lewis Hamilton", "123456", "9164567561", UserRole.Executor, projectId1),
                    new UserDTO("thi@email.com", "Kimi Raikkonen", "123456", "9164567561", UserRole.User, projectId1),
                    new UserDTO("fou@email.com", "Max Verstappen", "123456", "9164567561", UserRole.User, projectId1)
                );
            }

            context.SaveChanges();
            var userId1 = context.User.First().Id;
            var userId2 = context.User.Skip(1).First().Id;
            var userId3 = context.User.Skip(2).First().Id;
            var userId4 = context.User.Skip(3).First().Id;
            var userId5 = context.User.Skip(4).First().Id;

            var today = DateTime.Now;
            var yesterday = today.AddDays(-1);

            string longDescription = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Nulla aliquet enim tortor at auctor urna. Diam volutpat commodo sed egestas. 
Enim blandit volutpat maecenas volutpat blandit aliquam etiam erat velit. 
Eu nisl nunc mi ipsum faucibus vitae aliquet nec. Ut venenatis tellus in metus vulputate eu scelerisque. 
Malesuada fames ac turpis egestas. Faucibus scelerisque eleifend donec pretium vulputate. 
Tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi. ";

            if (!context.Ticket.Any())
            {
                context.Ticket.AddRange(
                    new TicketDTO(projectId1, userId4, "Server not works", longDescription, yesterday, today, ticketStatusId1, TicketOrigin.Web, TicketPriority.Low, userId2),
                    new TicketDTO(projectId1, userId4, "Application not works", "This is the description", yesterday, today, ticketStatusId1, TicketOrigin.Web, TicketPriority.Medium, userId2),
                    new TicketDTO(projectId1, userId5, "Printer HP not works", "This is the description", yesterday, today, ticketStatusId1, TicketOrigin.Web, TicketPriority.High, userId3),
                    new TicketDTO(projectId1, userId5, "Server not works", "This is the description", yesterday, today, ticketStatusId1, TicketOrigin.Web, TicketPriority.Critical, userId3)
                );
            }

            context.SaveChanges();
            var ticketId1 = context.Ticket.First().Id;

            if (!context.TicketComment.Any())
            {
                context.TicketComment.AddRange(
                    new TicketCommentDTO(ticketId1, yesterday, "This is first comment", userId1),
                    new TicketCommentDTO(ticketId1, yesterday, "This is second comment", userId1),
                    new TicketCommentDTO(ticketId1, today, "This is third comment", userId1),
                    new TicketCommentDTO(ticketId1, today, "This is fourth comment", userId1)
                );
            }

            context.SaveChanges();

            context.Ticket.First().Author = context.User.First(x => x.Role == UserRole.User);
            context.Ticket.First().Executor = context.User.First(x => x.Role == UserRole.Executor);
            context.Ticket.First().Project = context.Project.First();
            context.Ticket.First().Status = context.TicketStatus.First();
            context.Ticket.First().Comments = context.TicketComment.ToList();

            context.SaveChanges();
        }
    }
}
