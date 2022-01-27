using Data;
using NUnit.Framework;

namespace Test_Db
{
    public class MockRepositoryTests
    {
        IRepository repository;
        [SetUp]
        public void Setup()
        {
            repository = new MockRepository();
        }

        [Test]
        public void SelectProjects()
        {
            var projects = repository.SelectProjects();
            Assert.IsNotNull(projects);
            Assert.IsTrue(projects.Count > 0);
        }
    }
}