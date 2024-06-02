using System;
using Pacagroup.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Pacagroup.Ecommerce.Infrastructure.Data
{
	public class ConnectionFactory : IConnectionFactory
	{
		private readonly IConfiguration _congiguration;


		public ConnectionFactory(IConfiguration configuration)
		{
			this._congiguration = configuration;
		}

		public IDbConnection GetConnection
		{
			get
			{

				var sqlConnection = new SqlConnection();

				if (sqlConnection == null ) return null;

				sqlConnection.ConnectionString = this._congiguration.GetConnectionString("NorthwindConnection");
				sqlConnection.Open();

				return sqlConnection;

			}
		}
	}
}
