using Pacagroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Interface
{
	public interface ICategoriesDomain
	{

		public Task<IEnumerable<Categories>> GetAll();

	}
}
