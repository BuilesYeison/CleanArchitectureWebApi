using Application.Features.Foo.DTO;
using Application.Features.Foo.Queries;
using Application.Wrappers;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly ILogger<FooController> _logger;
        private readonly IMediator _mediator;

        public FooController(ILogger<FooController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllFoo")]
        public async Task<ActionResult> GetAllFoo([FromQuery] int pageNumber, int pageSize)
        {
            try
            {
                var result = await _mediator.Send(new GetAllFooQuery { PageNumber = pageNumber, PageSize = pageSize });
                return Ok(result);
            }
            catch (FooBarException ex) { //handle especific exception, for common/unhandled/global exceptions, middleware is going to handle it
                return BadRequest(ex.Message);
            }
        }
    }
}
