using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Commands.CreateCustomerCommand;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Commands.UpdateCustomerCommand;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Domain.Events;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Mappings
{
	public class MappingsProfile : Profile
	{
		public MappingsProfile()
		{
			/*
			 * Esto si queresmos ir campo por campo
			 
			CreateMap<Customer, CustomerDto>()
				.ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
				.ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
				.ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
				.ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
				.ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
				.ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
				.ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
				.ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
				.ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
				.ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
				.ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax)).ReverseMap();

			*/

			// Estos casos solo con esto funcionarían ya que las clases contienen lo mismos campos
			CreateMap<Customer, CustomerDto>().ReverseMap();
			CreateMap<Domain.Entities.User, UserDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			//CreateMap<Discount, DiscountDto>().ReverseMap();

			CreateMap<Discount, DiscountDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.Percent, opt => opt.MapFrom(src => src.Percent))
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
				.ReverseMap();

			CreateMap<Discount, DiscountCreatedEvent>().ReverseMap();
			CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
			CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
		}
	}
}
