
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkSampleAB.Application.Music.CreateUserPreferences;
using WorkSampleAB.Domain.Membership;
using WorkSampleAB.WebApi.Authentication;
using WorkSampleAB.WebApi.UserPreferences.Requests;

namespace WorkSampleAB.WebApi.UserPreferences
{
    [ApiController]
    [Route("[controller]")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserPreferencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserPreferencesRequest request)
        {
            var user = (User)HttpContext.Items["User"];
            var preferences = await _mediator.Send(
                new CreateUserPreferencesCommand(user.Id, request.Artists, request.Genres, request.Songs));
            return Ok(preferences);
        }

    }
}
