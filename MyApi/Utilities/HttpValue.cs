﻿namespace MyApi.Utilities
{
    public sealed class HttpValue
    {
        public HttpValue()
        {
            
        }

        public HttpValue(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}