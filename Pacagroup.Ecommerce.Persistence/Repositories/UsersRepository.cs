using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Persistence.Contexts;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using System.Data;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _dapperContext;

        public UsersRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public Users Authenticate(string username, string passowrd)
        {

            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";

                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", passowrd);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }

        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Users Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Users entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
