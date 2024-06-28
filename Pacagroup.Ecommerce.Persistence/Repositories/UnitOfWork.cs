using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Persistence.Contexts;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICustomersRepository Customers { get; }
        public IUsersRepository Users { get; }
        public ICategoriesRepository Categories { get; }
		public IDiscountRespository Discounts { get; }

		public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

		public async Task<int> Save(CancellationToken cancellationToken)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}

		public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories, IDiscountRespository discount, ApplicationDbContext applicationDbContext)
        {

            Customers = customers;
            Users = users;
            Categories = categories;
            Discounts = discount;
            _context = applicationDbContext;

        }
    }
}
