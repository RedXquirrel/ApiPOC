using System.Collections.Generic;

namespace MyApi.RequestTypes
{
    public abstract class BaseRequestType
    {
        public abstract IDictionary<string, object> JsonContent { get; }
    }
}