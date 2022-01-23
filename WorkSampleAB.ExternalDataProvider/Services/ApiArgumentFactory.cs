using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkSampleAB.ExternalDataProvider.Model;
using WorkSampleAB.ExternalDataProvider.Services.Interfaces;

namespace WorkSampleAB.ExternalDataProvider.Services
{
    public class ApiArgumentFactory : IApiArgumentFactory
    {
        public ApiArgument[] CreateArguments(string name, string values)
        {
            var arguments = values.Split(',');
            var apiArguments = arguments.Select(x => new ApiArgument
            {
                Name = name,
                Value = x
            }).ToArray();
            return apiArguments;
        }
    }
}
