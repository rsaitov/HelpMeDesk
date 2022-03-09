using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class EFRepositoryProject : IRepositoryProject
    {
        private readonly HelpMeDeskContext _context;
        public EFRepositoryProject(HelpMeDeskContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectDTO> SelectAll()
        {
            return _context.Project
                .ToList();
        }

        public ProjectDTO Select(int id)
        {
            return _context.Project
                .FirstOrDefault(x => x.Id == id);
        }
        public ProjectDTO Insert(ProjectDTO project)
        {
            _context.Project.Add(project);
            _context.SaveChanges();
            return project;
        }

        public ProjectDTO Update(ProjectDTO user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
    }
}
