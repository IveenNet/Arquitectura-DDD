using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.Validatior;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Discounts
{
	public class DiscountsApplication : IDiscountsApplication
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly DiscountDtoValidator _discountDtoValidator;

		public DiscountsApplication(IUnitOfWork unitOfWork, IMapper mapper, DiscountDtoValidator discountDtoValidator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_discountDtoValidator = discountDtoValidator;
		}

		public async Task<Response<bool>> CreateAsync(DiscountDto discountDto, CancellationToken cancellationToken = default)
		{
			return await HandleRequest(async () =>
			{
				await ValidateDiscountDtoAsync(discountDto, cancellationToken);
				var discount = _mapper.Map<Discount>(discountDto);
				await _unitOfWork.Discounts.InsertAsync(discount);
				return await _unitOfWork.Save(cancellationToken) > 0;
			});
		}

		public async Task<Response<bool>> UpdateAsync(DiscountDto discountDto, CancellationToken cancellationToken = default)
		{
			return await HandleRequest(async () =>
			{
				await ValidateDiscountDtoAsync(discountDto, cancellationToken);
				var discount = _mapper.Map<Discount>(discountDto);
				await _unitOfWork.Discounts.UpdateAsync(discount);
				return await _unitOfWork.Save(cancellationToken) > 0;
			});
		}

		public async Task<Response<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
		{
			return await HandleRequest(async () =>
			{
				await _unitOfWork.Discounts.DeleteAsync(id.ToString());
				return await _unitOfWork.Save(cancellationToken) > 0;
			});
		}

		public async Task<Response<DiscountDto>> GetAsync(int id, CancellationToken cancellationToken = default)
		{
			return await HandleRequest(async () =>
			{
				var discount = await _unitOfWork.Discounts.GetAsync(id.ToString(), cancellationToken);
				return _mapper.Map<DiscountDto>(discount);
			});
		}

		public async Task<Response<List<DiscountDto>>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await HandleRequest(async () =>
			{
				var discounts = await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
				return _mapper.Map<List<DiscountDto>>(discounts);
			});
		}

		private async Task ValidateDiscountDtoAsync(DiscountDto discountDto, CancellationToken cancellationToken)
		{
			var validation = await _discountDtoValidator.ValidateAsync(discountDto, cancellationToken);
			if (!validation.IsValid)
				throw new ValidationException("Errores de Validacion");
		}

		private async Task<Response<T>> HandleRequest<T>(Func<Task<T>> action)
		{
			var response = new Response<T>();
			try
			{
				response.Data = await action();
				response.IsSuccess = true;
				response.Message = "Operación Exitosa!!";
			}
			catch (ValidationException ex)
			{
				response.Message = ex.Message;
			}
			catch (Exception ex)
			{
				response.Message = ex.Message;
			}
			return response;
		}
	}

	public class ValidationException : Exception
	{
		public List<string> Errors { get; }

		public ValidationException(string message) : base(message)
		{
			
		}
	}
}
