using Application.Features.Foo.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class FooProfile : Profile
    {
        public FooProfile()
        {
            CreateMap<Foo, FooDTO>().ReverseMap();
        }
    }
}
