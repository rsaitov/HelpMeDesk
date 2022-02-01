using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ProjectDTO
    {
        public int Id { get; }
        public string Name { get; }

        public ProjectDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
