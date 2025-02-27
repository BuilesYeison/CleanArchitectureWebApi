using Application.Features.Foo.DTO;
using Application.Features.Foo.Queries;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Foo.Handlers
{
    public class GetAllFooHandler : IRequestHandler<GetAllFooQuery, PagedResponse<IEnumerable<FooDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IFooRepository _fooRepository;

        public GetAllFooHandler(IMapper mapper,IFooRepository fooRepository)
        {
            _fooRepository = fooRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<FooDTO>>> Handle(GetAllFooQuery request, CancellationToken cancellationToken)
        {
            var (fooItems,totalRecords) = await _fooRepository.GetAllAsync(request.PageNumber,request.PageSize);

            var mappedItems = _mapper.Map<IEnumerable<FooDTO>>(fooItems);

            var result = new PagedResponse<IEnumerable<FooDTO>>(mappedItems,request.PageNumber,request.PageSize,totalRecords);
            return result;
        }
    }
}
