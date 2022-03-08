using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.ViewModels
{
    public class TicketViewModel : TicketDTO
    {
        public new int? Id { get; set; }

        public UserDTO User;

        public IEnumerable<TicketStatusDTO> TicketStatuses;
        public IEnumerable<ProjectDTO> Projects;
        public IEnumerable<UserDTO> Users;

        public bool CommentAccess { get; set; }
    }
}
