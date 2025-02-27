using Application.Features.Foo.DTO;
using Application.Features.Foo.Queries;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Foo.Handlers
{
    public class GetAllFooHandler : IRequestHandler<GetAllFooQuery, PagedResponse<IEnumerable<FooDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IFooRepository _fooRepository;
        private readonly IMessageService _messageService;

        public GetAllFooHandler(IMapper mapper,IFooRepository fooRepository,IMessageService messageService)
        {
            _fooRepository = fooRepository;
            _mapper = mapper;
            _messageService = messageService;
        }

        public async Task<PagedResponse<IEnumerable<FooDTO>>> Handle(GetAllFooQuery request, CancellationToken cancellationToken)
        {
            var (fooItems,totalRecords) = await _fooRepository.GetAllAsync(request.PageNumber,request.PageSize);

            var mappedItems = _mapper.Map<IEnumerable<FooDTO>>(fooItems);
            await _messageService.SendMessageAsync("test@mail.com", "Data getted", "Notifying");
            var result = new PagedResponse<IEnumerable<FooDTO>>(mappedItems,request.PageNumber,request.PageSize,totalRecords);
            return result;
        }
    }
}
