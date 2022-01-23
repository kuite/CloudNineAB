using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WorkSampleAB.DomainLogic.Membership;

namespace WorkSampleAB.Application.Membership.GetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IAccountService _accountService;

        public GetTokenQueryHandler(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetByLoginCredentials(request.UserEmail, request.Password);
            if (user == null)
            {
                throw new KeyNotFoundException("User not exist");
            }

            var token = _accountService.GenerateToken(user);

            return token;
        }

    }
}
