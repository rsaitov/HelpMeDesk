using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.ViewModels
{
    public class ProjectListViewModel
    {
        public readonly IEnumerable<ProjectDTO> Projects;

        public ProjectListViewModel(IEnumerable<ProjectDTO> projects)
        {
            Projects = projects;
        }
    }
}
