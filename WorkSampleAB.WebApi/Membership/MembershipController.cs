using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkSampleAB.Application.Membership.GetToken;
using WorkSampleAB.WebApi.Membership.Requests;

namespace WorkSampleAB.WebApi.Membership
{
    [ApiController]
    [Route("[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Get([FromBody] GetTokenRequest request)
        {
            var token = await _mediator.Send(new GetTokenQuery(request.UserEmail, request.Password));
            return Ok(token);
        }
    }
}
