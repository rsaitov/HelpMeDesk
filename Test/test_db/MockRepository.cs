using Data;
using NUnit.Framework;
using System.Linq;

namespace Test_Db
{
    public class MockRepositoryTests
    {
        IRepositoryUser repositoryUser;
        IRepositoryProject repositoryProject;
        IRepositoryTicket repositoryTicket;
        IRepositoryTicketComment repositoryTicketComment;
        IRepositoryTicketStatus repositoryTicketStatus;
        [SetUp]
        public void Setup()
        {
            repositoryUser = new MockRepositoryUser();
            repositoryProject = new MockRepositoryProject();
            repositoryTicket = new MockRepositoryTicket();
            repositoryTicketComment = new MockRepositoryTicketComment();
            repositoryTicketStatus = new MockRepositoryTicketStatus();
        }

        [Test]
        public void SelectProjects()
        {
            var projects = repositoryProject.SelectAll();
            Assert.IsNotNull(projects);
            Assert.IsTrue(projects.Count() > 0);
        }

        [Test]
        public void SelectUsers()
        {
            var users = repositoryUser.SelectAll();
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count() > 0);
        }

        [Test]
        public void SelectTickets()
        {
            var tickets = repositoryTicket.SelectAll();
            Assert.IsNotNull(tickets);
            Assert.IsTrue(tickets.Count() > 0);
        }

        [Test]
        public void SelectTicketComments()
        {
            var ticketComments = repositoryTicketComment.SelectAll();
            Assert.IsNotNull(ticketComments);
            Assert.IsTrue(ticketComments.Count() > 0);
        }

        [Test]
        public void SelectTicketStatuses()
        {
            var ticketStatuses = repositoryTicketStatus.SelectAll();
            Assert.IsNotNull(ticketStatuses);
            Assert.IsTrue(ticketStatuses.Count() > 0);
        }
    }
}