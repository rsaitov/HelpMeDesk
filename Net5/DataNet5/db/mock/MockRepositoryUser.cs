using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
	public class MockRepositoryUser : IRepositoryUser
	{
		private List<UserDTO> _users;
		public MockRepositoryUser()
		{
			_users = new List<UserDTO>() {
				new UserDTO(1, "admin@email.com", "Rinat Saitov", "123456", "9164567561", UserRole.Administrator, 1),
				new UserDTO(2, "first@email.com", "Fernando Alonso", "123456", "9164567561", UserRole.Executor, 1),
				new UserDTO(3, "second@email.com", "Lewis Hamilton", "123456", "9164567561", UserRole.Executor, 1),
				new UserDTO(4, "third@email.com", "Kimi Raikkonen", "123456", "9164567561", UserRole.User, 1),
				new UserDTO(5, "fourth@email.com", "Max Verstappen", "123456", "9164567561", UserRole.User, 1),
			};
		}
		public IEnumerable<UserDTO> SelectAll()
		{
			return _users;
		}
		public UserDTO Select(int id)
		{
			return _users.FirstOrDefault(x => x.Id == id);
		}

		public UserDTO Insert(UserDTO user)
		{
			user.Id = _users.Max(x => x.Id) + 1;
			_users.Add(user);
			return user;
		}
		public UserDTO Update(UserDTO user)
		{
			return user;
		}

		public UserDTO SelectByEmail(string email, string password = null)
		{
			email = email.ToLowerInvariant();
			return _users.FirstOrDefault(x => string.Equals(x.Email, email) &&
											 (ReferenceEquals(null, password) || string.Equals(x.Password, password)));
		}
		public bool Exists(string email)
		{
			email = email.ToLowerInvariant();
			return _users.Any(x => email == x.Email);
		}
	}
}