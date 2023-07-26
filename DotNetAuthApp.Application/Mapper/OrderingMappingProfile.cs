using AutoMapper;
using DotNetAuthApp.Application.Commands;
using DotNetAuthApp.Application.Response;
using DotNetAuthApp.Core.Entities;

namespace DotNetAuthApp.Application.Mapper
{
    public class OrderingMappingProfile : Profile
    {
        public OrderingMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, EditCustomerCommand>().ReverseMap();
        }
    }
}
