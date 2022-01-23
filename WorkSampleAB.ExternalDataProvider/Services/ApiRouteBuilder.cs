using System.Linq;
using System.Text;
using WorkSampleAB.ExternalDataProvider.Model;
using WorkSampleAB.ExternalDataProvider.Services.Interfaces;

namespace WorkSampleAB.ExternalDataProvider.Services
{
    public class ApiRouteBuilder : IApiRouteBuilder, IApiAddressBuilderSetter, 
        IApiVersionBuilderSetter, IApiBranchBuilderSetter, IApiArgumentsBuilderSetter
    {
        private readonly StringBuilder _mStringBuilder;
        private const char ArgumentsStartSign = '?';
        private const char ArgumentConcatSign = '&';

        public ApiRouteBuilder(StringBuilder stringBuilder)
        {
            _mStringBuilder = stringBuilder;
        }

        public string Build()
        {
            return _mStringBuilder.ToString();
        }

        public IApiVersionBuilderSetter SetAddress(string address)
        {
            _mStringBuilder.Append($"{address}/");

            return this;
        }

        public IApiAddressBuilderSetter SetProtocol(string protocol)
        {
            _mStringBuilder.Append($@"{protocol}://");

            return this;
        }

        public ApiRouteBuilder SetArguments(params ApiArgument[] arguments)
        {
            var cleanedArguments = arguments.ToList()
                .GroupBy(x => x.Name)
                .Select(x => new ApiArgument { Name = x.Key, Value = x.First().Value })
                .ToList();

            foreach (var argument in cleanedArguments)
            {
                var currentValue = _mStringBuilder.ToString();
                var lastSign = currentValue.Last();
                if (lastSign == ArgumentsStartSign || lastSign == ArgumentConcatSign)
                {
                    _mStringBuilder.Append($"{argument.Name}={argument.Value}{ArgumentConcatSign}");
                }
                else
                {
                    _mStringBuilder.Append($"{ArgumentsStartSign}{argument.Name}={argument.Value}{ArgumentConcatSign}");
                }
            }

            return this;
        }

        public IApiArgumentsBuilderSetter SetBranch(string branch)
        {
            _mStringBuilder.Append($"{branch}");

            return this;
        }

        public IApiBranchBuilderSetter SetVersion(string version)
        {
            _mStringBuilder.Append($"{version}/");

            return this;
        }

    }
}
