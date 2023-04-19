using Application.Employees.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _mediator.Send(command);

            if(result.Successed)
                return CreatedAtAction(nameof(CreateEmployee), result.Id);
            return BadRequest();
        }
    }
}
