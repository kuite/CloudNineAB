﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSampleAB.ExternalDataProvider.Services.Interfaces
{
    public interface IApiRouteBuilder : IApiProtocolBuilderSetter
    {
        string Build();
    }
}
