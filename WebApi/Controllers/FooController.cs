using Application.Features.Foo.DTO;
using Application.Features.Foo.Queries;
using Application.Wrappers;
using Domain.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly ILogger<FooController> _logger;
        private readonly IMediator _mediator;
        private readonly IValidator<FooDTO> _fooValidator;

        public FooController(ILogger<FooController> logger, IMediator mediator,IValidator<FooDTO> fooValidator)
        {
            _fooValidator = fooValidator;
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

        [HttpPost(Name = "CreateFoo")]
        public async Task<ActionResult> CreateFoo([FromBody] FooDTO fooDTO)
        {
            var validationResult = await _fooValidator.ValidateAsync(fooDTO);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(new ApiResponse<ModelStateDictionary>(ModelState,"Validation errors",false));
            }

            return Ok(new ApiResponse<FooDTO>(fooDTO, "Foo has been created"));
        }
    }
}
