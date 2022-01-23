using System;
using System.Collections.Generic;
using System.Text;
using WorkSampleAB.ExternalDataProvider.Model;

namespace WorkSampleAB.ExternalDataProvider.Services.Interfaces
{
    public interface IApiArgumentFactory
    {
        ApiArgument[] CreateArguments(string name, string values);
    }
}
