using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Data;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
	public class UsersRepository : IUsersRepository
	{
		private readonly IConnectionFactory _connectionFactory;

		public UsersRepository(IConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public Users Authenticate(string username, string passowrd)
		{

			using (var connection = _connectionFactory.GetConnection)
			{
				var query = "UsersGetByUserAndPassword";

				var parameters = new DynamicParameters();
				parameters.Add("UserName", username);
				parameters.Add("Password", passowrd);

				var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
				return user;
			}

		}

	}
}
