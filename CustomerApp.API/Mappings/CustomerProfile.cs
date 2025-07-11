using AutoMapper;
using CustomerApp.API.Shared.Models;
using CustomerApp.Shared.Models;

namespace CustomerApp.API.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
