using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSampleAB.ExternalDataProvider.Services.Interfaces
{
    public interface IApiBranchBuilderSetter
    {
        IApiArgumentsBuilderSetter SetBranch(string branch);
    }
}
