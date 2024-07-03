using Microsoft.EntityFrameworkCore;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Persistence.Contexts;
using Pacagroup.Ecommerce.Persistence.Mocks;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
	public class DiscountRepository : IDiscountRespository
	{

		protected readonly ApplicationDbContext _context;

		public DiscountRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		#region Metodos Sincronos

		public int Count()
		{
			throw new NotImplementedException();
		}

		public bool Delete(string id)
		{
			throw new NotImplementedException();
		}

		public Discount Get(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Discount> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Discount> GetAllWithPagination(int pageNumber, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task<Discount> GetById(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool Insert(Discount entity)
		{
			throw new NotImplementedException();
		}

		public bool Update(Discount entity)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Metodos Asincronos

		public Task<IEnumerable<Discount>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _context.Set<Discount>()
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		}

		public async Task<IEnumerable<Discount>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
		{

			var faker = new DiscountGetAllWithPaginationAsyncBogusCongif();
			var result = await Task.Run(() => faker.Generate(100));

			return result.Skip((pageNumber - 1)*pageSize).Take(pageSize);

		}

		public async Task<int> CountAsync()
		{

			return await Task.Run(() => 1000);

		}

		public Task<Discount> GetAsync(string id)
		{
			throw new NotImplementedException();
		}

		public async Task<Discount> GetAsync(string id, CancellationToken cancellationToken)
		{
			return await _context.Set<Discount>()
				.AsNoTracking()
				.SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(id)));
		}

		public async Task<bool> InsertAsync(Discount entity)
		{

			_context.Add(entity);

			return await Task.FromResult(true);

		}

		public async Task<bool> UpdateAsync(Discount discount)
		{
			var entity = await _context.Set<Discount>()
				.AsNoTracking()
				.SingleOrDefaultAsync(x => x.Id.Equals(discount.Id));

			if(entity is null) return await Task.FromResult(false);

			entity.Name = discount.Name;
			entity.Description = discount.Description;
			entity.Percent = discount.Percent;
			entity.Status = discount.Status;

			_context.Update(entity);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteAsync(string id)
		{
			var entity = await _context.Set<Discount>()
				.AsNoTracking()
				.SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(id)));

			if (entity is null) return await Task.FromResult(false);

			_context.Remove(entity);

			return await Task.FromResult(true);
		}

		#endregion
	}
}
