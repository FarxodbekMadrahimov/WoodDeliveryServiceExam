
using JWT.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Request.Domain.Entitites.Users;
using System.Numerics;
using Wood.Application.Usecases.Users.Commands;
using Wood.Application.Usecases.Users.Queries;

namespace Wood.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;


        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost]
        [PermissionFilter(permission: "CreateUser")]
        [LoggerFilter]
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateUserCommand users)
        {
            int result = await _mediator.Send(users);

            return Ok(result);
        }
        [HttpGet]
        [PermissionFilter(permission: "CreateUser")]
        [LoggerFilter]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<User> classes = await _mediator.Send(new GetAllUsersQuery());

            return Ok(classes);
        }
        [HttpPut]
        [PermissionFilter(permission: "CreateUser")]
        [LoggerFilter]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateUserCommand user)
        {
            int result = await _mediator.Send(user);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [PermissionFilter(permission: "CreateUser")]
        [LoggerFilter]
        public async ValueTask<IActionResult> DeleteAsync(int classId)
        {
            DeleteUsersCommand @class = new DeleteUsersCommand()
            {
                Id = classId
            };

            int result = await _mediator.Send(@class);

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        [PermissionFilter(permission: "CreateUser")]
        [LoggerFilter]
        public async ValueTask<IActionResult> GetByIdAsync(int Id)
        {
            GetUserByIdQuery doctor = new GetUserByIdQuery()
            {
                Id = Id,
            };

            User result = await _mediator.Send(doctor);

            return Ok(result);
        }
    }
}
