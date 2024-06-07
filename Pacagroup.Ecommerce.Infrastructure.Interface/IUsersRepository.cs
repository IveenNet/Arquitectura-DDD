using Pacagroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
	public interface IUsersRepository
	{

		Users Authenticate(string username, string password);

	}
}
