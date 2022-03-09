using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MockRepositoryProject : IRepositoryProject
    {
        private List<ProjectDTO> _projects;
        public MockRepositoryProject()
        {
            _projects = new List<ProjectDTO>() {
                new ProjectDTO("Mercedes"),
                new ProjectDTO("Red Bull"),
                new ProjectDTO("Ferrari"),
            };
        }

        public IEnumerable<ProjectDTO> SelectAll()
        {
            return _projects;
        }
        public ProjectDTO Select(int id)
        {
            return _projects.FirstOrDefault(x => x.Id == id);
        }
        public ProjectDTO Insert(ProjectDTO project)
        {
            project.Id = _projects.Max(x => x.Id) + 1;
            _projects.Add(project);
            return project;
        }

        public ProjectDTO Update(ProjectDTO project)
        {
            return project;
        }
    }
}
