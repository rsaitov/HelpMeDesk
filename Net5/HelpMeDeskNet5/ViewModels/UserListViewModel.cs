using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.ViewModels
{
    public class UserListViewModel
    {
        public readonly IEnumerable<UserDTO> Users;

        public UserListViewModel(IEnumerable<UserDTO> users)
        {
            Users = users;
        }
    }
}
