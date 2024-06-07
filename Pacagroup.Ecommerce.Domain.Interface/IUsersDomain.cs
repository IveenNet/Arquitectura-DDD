using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Domain.Interface
{
	public interface IUsersDomain
	{

		public Users Authenticate(string username, string password);

	}
}
