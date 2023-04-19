using Application.Dishes.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {

        private readonly IMediator mediator;
        public DishController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromBody] DishCreateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await mediator.Send(command);
            if (!result.Successed)
                return BadRequest("Failed to create entity");

            return CreatedAtAction(nameof(CreateDish), result.Id);
        }
    }
}
