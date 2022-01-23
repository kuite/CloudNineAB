using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkSampleAB.ExternalDataProvider.Model;

namespace WorkSampleAB.ExternalDataProvider.Services.Interfaces
{
    public interface IRequestCreator
    {
        Task<HttpWebRequest> CreateRecommendationsRequest(params ApiArgument[] arguments);
    }
}
