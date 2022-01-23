using System;
using System.Collections.Generic;
using System.Text;
using WorkSampleAB.ExternalDataProvider.Model;

namespace WorkSampleAB.ExternalDataProvider.Services.Interfaces
{
    public interface IApiArgumentsBuilderSetter
    {
        ApiRouteBuilder SetArguments(params ApiArgument[] arguments);
    }
}
