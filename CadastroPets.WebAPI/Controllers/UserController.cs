using CadastroPets.Application.Commands;
using CadastroPets.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPets.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region Properties

        private readonly IMediator _mediator;

        #endregion

        #region Constructors

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Queries

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return user.Id != 0 ? Ok(user) : NotFound();
        }

        #endregion

        #region Persistênce

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction("CreateUser", new { id = userId }, userId);
        }

        #endregion
    }

}
