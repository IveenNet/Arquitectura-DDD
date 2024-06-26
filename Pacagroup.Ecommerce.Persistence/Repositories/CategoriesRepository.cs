using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Persistence.Contexts;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using System.Data;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly DapperContext _dapperContext;

        public CategoriesRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {

            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "Select * from Categories";

                var categorias = await connection.QueryAsync<Category>(query, commandType: CommandType.Text);
                return categorias;
            }

        }
    }
}
