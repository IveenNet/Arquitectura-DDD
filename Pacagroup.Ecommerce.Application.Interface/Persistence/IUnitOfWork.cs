﻿namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
	public interface IUnitOfWork  : IDisposable
	{

		ICustomersRepository Customers { get; }
		IUsersRepository Users { get; }
		ICategoriesRepository Categories { get; }
		IDiscountRespository Discounts { get; }
		Task<int> Save(CancellationToken cancellationToken);
	}
}
