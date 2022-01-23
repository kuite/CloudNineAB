using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkSampleAB.ExternalDataProvider.Model;

namespace WorkSampleAB.ExternalDataProvider.Services.Interfaces
{
    public interface ITokenHandler
    {
        Task<SpotifyToken> GetToken();
    }
}
