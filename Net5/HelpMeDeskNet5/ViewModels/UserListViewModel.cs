using Data;
using System.Collections.Generic;

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
