using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfCoreUserRepository : EfCoreRepository<UserDTO, HelpMeDeskContext>
    {
        private readonly HelpMeDeskContext _context;
        public EfCoreUserRepository(HelpMeDeskContext context) : base(context)
        {
            _context = context;
        }
        public UserDTO Get(string email, string password = null)
        {
            email = email.ToLowerInvariant();
            return _context.User.FirstOrDefault(x => string.Equals(x.Email, email) &&
                                             (ReferenceEquals(null, password) || string.Equals(x.Password, password)));
        }
        public bool Exists(string email)
        {
            email = email.ToLowerInvariant();
            return _context.User.Any(x => string.Equals(x.Email, email));
        }
    }
}
