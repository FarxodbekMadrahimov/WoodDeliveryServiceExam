using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Request;
using Wood.Application.Usecases.Orders.Queries;
using Wood.Application.Usecases.Requests.Commands;
using Wood.Application.Usecases.Requests.Handlers;
using Wood.Application.Usecases.Requests.Queries;
using Wood.Application.Usecases.Users.Commands;
using Wood.Application.Usecases.Users.Queries;

namespace Wood.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(CreateRequestCommand rq)
        {
            int result = await _mediator.Send(rq);

            return Ok(result);
        }
        [HttpGet]

        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Requesting> classes = await _mediator.Send(new GetAllRequestQuery());

            return Ok(classes);
        }
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync(int classId)
        {
            DeleteRequestCommand @class = new DeleteRequestCommand()
            {
                Id = classId
            };

            int result = await _mediator.Send(@class);

            return Ok(result);
        
        }


    }
}
