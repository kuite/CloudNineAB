using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WorkSampleAB.Application.Membership.GetToken
{
    public class GetTokenQuery : IRequest<string>
    {
        public string UserEmail { get; }
        public string Password { get; }

        public GetTokenQuery(string userEmail, string password)
        {
            UserEmail = userEmail;
            Password = password;
        }
        
    }
}
