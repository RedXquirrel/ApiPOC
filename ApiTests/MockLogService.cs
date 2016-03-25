using System;
using System.Diagnostics;
using MyApi.Interfaces;

namespace ApiTests
{
    public class MockLogService : ILogService
    {
        public void Error(string message)
        {
            Debug.WriteLine($"Error: {message}");
        }

        public void Info(string message)
        {
            Debug.WriteLine($"Info: {message}");
        }

        public void Warning(string message)
        {
            Debug.WriteLine($"Warning: {message}");
        }
    }
}