using Data;
using Domain.service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.test_db
{
    public class TicketTests
    {
        private IService _service;

        public TicketTests()
        {
            _service = new Service(
                new MockRepositoryProject(),
                new MockRepositoryUser(),
                new MockRepositoryTicketComment(),
                new MockRepositoryTicketStatus(),
                new MockRepositoryTicket()
                );
        }

        [SetUp]
        public void Setup( )
        {
            
        }

        [Test]
        public void HaveAccessToComment_NoAccess()
        {
            var users = _service.GetAllUsers();
            var clientUser = users.FirstOrDefault(x => x.Role == UserRole.User);

            var tickets = _service.GetAllTickets();
            var firstTicket = tickets.FirstOrDefault(x => x.AuthorId != clientUser.Id);

            var haveAccess = _service.HaveAccessToComment(firstTicket, clientUser.Email);
            Assert.IsFalse(haveAccess);
        }
        [Test]
        public void TryToComment_NoAccess()
        {
            var users = _service.GetAllUsers();
            var clientUser = users.FirstOrDefault(x => x.Role == UserRole.User);

            var tickets = _service.GetAllTickets();
            var firstTicket = tickets.FirstOrDefault(x => x.AuthorId != clientUser.Id);

            var ticketComment = new TicketCommentDTO(firstTicket.Id, DateTime.Now, "my comment");

            var addedComment = _service.AddTicketComment(ticketComment, clientUser.Email);
            Assert.IsNull(addedComment);
        }
        [Test]
        public void TryToCommentByAdmin_Success()
        {
            var users = _service.GetAllUsers();
            var adminUser = users.FirstOrDefault(x => x.Role == UserRole.Administrator);

            var tickets = _service.GetAllTickets();
            var firstTicket = tickets.FirstOrDefault(x => x.AuthorId != adminUser.Id);

            var ticketComment = new TicketCommentDTO(firstTicket.Id, DateTime.Now, "my comment");

            var addedComment = _service.AddTicketComment(ticketComment, adminUser.Email);
            Assert.IsNotNull(addedComment);            
        }
    }
}
