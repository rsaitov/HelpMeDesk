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
            
        }

        [SetUp]
        public void Setup( )
        {
            
        }

        [Test]
        public void Comment_NoAccess()
        {
            var users = _service.GetAllUsers();
            var clientUser = users.FirstOrDefault(x => x.Role == UserRole.User);

            var tickets = _service.GetAllTickets();
            var firstTicket = tickets.FirstOrDefault(x => x.AuthorId != clientUser.Id);

            var haveAccess = _service.HaveAccessToComment(firstTicket, clientUser.Email);
            Assert.IsFalse(haveAccess);
        }
    }
}
