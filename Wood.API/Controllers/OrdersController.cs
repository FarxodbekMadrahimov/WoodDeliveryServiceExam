using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Request;
using Wood.Application.Usecases.Orders.Commands;
using Wood.Application.Usecases.Orders.Queries;
using Wood.Application.Usecases.Requests.Commands;
using Wood.Application.Usecases.Requests.Queries;

namespace Wood.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateOrderCommand rq)
        {
            int result = await _mediator.Send(rq);

            return Ok(result);
        }
        

        [HttpGet]

        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Order> classes = await _mediator.Send(new GetAllOrderQuery());

            return Ok(classes);
        }
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync(int classId)
        {
            DeleteOrderCommand @class = new DeleteOrderCommand()
            {
                Id = classId
            };

            int result = await _mediator.Send(@class);

            return Ok(result);

        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetByIdAsync(int Id)
        {
            GetOrderByIdQuery doctor = new GetOrderByIdQuery()
            {
                Id = Id,
            };

            Order result = await _mediator.Send(doctor);

            return Ok(result);
        }

    }
}
