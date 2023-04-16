using Application.Restaurants.Commands;
using Application.Restaurants.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private readonly IMediator _mediator;
        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);
            if (!result.Successed)
                BadRequest("Failed to create entity");

            return CreatedAtAction(nameof(CreateRestaurant),result.Id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery { Id = id });

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

    }
}
