using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class EFRepositoryUser : IRepositoryUser
    {
        private readonly HelpMeDeskContext _context;
        public EFRepositoryUser(HelpMeDeskContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDTO> SelectAll()
        {
            return _context.User
                .Include(x => x.Project)
                .ToList();
        }

        public UserDTO Select(int id)
        {
            return _context.User
                .Include(x => x.Project)
                .FirstOrDefault(x => x.Id == id);
        }
        public UserDTO Insert(UserDTO user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserDTO Update(UserDTO user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public UserDTO SelectByEmail(string email, string password = null)
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
