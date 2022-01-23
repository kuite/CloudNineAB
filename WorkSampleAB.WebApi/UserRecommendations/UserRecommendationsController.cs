using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkSampleAB.Application.Music.GetUserRecommendations;
using WorkSampleAB.Domain.Membership;
using WorkSampleAB.WebApi.Authentication;

namespace WorkSampleAB.WebApi.UserRecommendations
{
    [ApiController]
    [Route("[controller]")]
    public class UserRecommendationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRecommendationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var user = (User)HttpContext.Items["User"];
            var recommendation = await _mediator.Send(new GetUserRecommendationsQuery(user.Id));
            return Ok(recommendation);
        }
    }
}
