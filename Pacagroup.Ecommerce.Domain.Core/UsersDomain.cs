using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
	public class UsersDomain : IUsersDomain
	{

		private readonly IUsersRepository _usersRepository;

		public UsersDomain(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public Users Authenticate(string username, string password)
		{
			return _usersRepository.Authenticate(username, password);
		}
	}
}
