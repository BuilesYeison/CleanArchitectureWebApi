using Application.Features.Foo.DTO;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Foo.Queries
{
    public class GetAllFooQuery : IPaginatedQuery , IRequest<PagedResponse<IEnumerable<FooDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
