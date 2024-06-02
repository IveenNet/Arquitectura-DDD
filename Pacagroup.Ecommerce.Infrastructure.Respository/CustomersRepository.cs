using System;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infrastructure.Respository
{
	public class CustomersRepository : ICustomerRepository
	{

		private readonly IConnectionFactory _connectionFactory;


		public CustomersRepository(IConnectionFactory connectionFactory)
		{
			this._connectionFactory = connectionFactory;
		}


		#region Métodos Síncronos

		public bool Insert(Customers customers)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersInsert";
				
				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customers.CustomerId);
				parameters.Add("CompanyName", customers.CompanyName);
				parameters.Add("ContactName", customers.ContactName);
				parameters.Add("ContactTitle", customers.ContactTitle);
				parameters.Add("Address", customers.Address);
				parameters.Add("City", customers.City);
				parameters.Add("Region", customers.Region);
				parameters.Add("PostalCode", customers.PostalCode);
				parameters.Add("Country", customers.Country);
				parameters.Add("Phone", customers.Phone);
				parameters.Add("Fax", customers.Fax);

				var result = connection.Execute(query, param:parameters, commandType:CommandType.StoredProcedure);

				return result > 0;
			}
		}

		public bool Update(Customers customers)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersUpdate";

				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customers.CustomerId);
				parameters.Add("CompanyName", customers.CompanyName);
				parameters.Add("ContactName", customers.ContactName);
				parameters.Add("ContactTitle", customers.ContactTitle);
				parameters.Add("Address", customers.Address);
				parameters.Add("City", customers.City);
				parameters.Add("Region", customers.Region);
				parameters.Add("PostalCode", customers.PostalCode);
				parameters.Add("Country", customers.Country);
				parameters.Add("Phone", customers.Phone);
				parameters.Add("Fax", customers.Fax);

				var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

				return result > 0;
			}
		}

		public bool Delete(string customersId)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersDelete";

				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customersId);

				var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

				return result > 0;
			}
		}

		public Customers Get(string customersId)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersGetById";

				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customersId);

				var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);

				return customer;
			}
		}

		public IEnumerable<Customers> GetAll()
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersList";

				var customers = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);

				return customers;
			}
		}

		#endregion


		#region Métodos Asíncronos

		public async Task<bool> InsertAsync(Customers customers)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersInsert";

				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customers.CustomerId);
				parameters.Add("CompanyName", customers.CompanyName);
				parameters.Add("ContactName", customers.ContactName);
				parameters.Add("ContactTitle", customers.ContactTitle);
				parameters.Add("Address", customers.Address);
				parameters.Add("City", customers.City);
				parameters.Add("Region", customers.Region);
				parameters.Add("PostalCode", customers.PostalCode);
				parameters.Add("Country", customers.Country);
				parameters.Add("Phone", customers.Phone);
				parameters.Add("Fax", customers.Fax);

				var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

				return result > 0;
			}
		}

		public async Task<bool> UpdateAsync(Customers customers)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersInsert";

				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customers.CustomerId);
				parameters.Add("CompanyName", customers.CompanyName);
				parameters.Add("ContactName", customers.ContactName);
				parameters.Add("ContactTitle", customers.ContactTitle);
				parameters.Add("Address", customers.Address);
				parameters.Add("City", customers.City);
				parameters.Add("Region", customers.Region);
				parameters.Add("PostalCode", customers.PostalCode);
				parameters.Add("Country", customers.Country);
				parameters.Add("Phone", customers.Phone);
				parameters.Add("Fax", customers.Fax);

				var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

				return result > 0;
			}
		}

		public async Task<bool> DeleteAsync(string customersId)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersDelete";

				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customersId);

				var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

				return result > 0;
			}
		}

		public async Task<Customers> GetAsync(string customersId)
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersGetById";

				var parameters = new DynamicParameters();
				parameters.Add("CustomerId", customersId);

				var customer = await connection.QuerySingleAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);

				return customer;
			}
		}

		public async Task<IEnumerable<Customers>> GetAllAsync()
		{
			using (var connection = this._connectionFactory.GetConnection)
			{

				var query = "CustomersList";

				var customers = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);

				return customers;
			}
		}

		#endregion

	}
}