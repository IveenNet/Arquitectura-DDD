using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using System.Data;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
	public class CategoriesRepository : ICategoriesRepository
	{

		private readonly DapperContext _dapperContext;

		public CategoriesRepository(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		public async Task<IEnumerable<Categories>> GetAll()
		{

			using (var connection = _dapperContext.CreateConnection()){
				var query = "Select * from Categories";

				var categorias = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
				return categorias;
			}

		}
	}
}
