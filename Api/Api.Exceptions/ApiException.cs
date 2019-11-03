using System;

namespace Api.Exceptions
{
    /// <summary>
    /// A custom exception used when the API does not return a success message
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException() : base() { }

        public ApiException(string message) : base(message) { }
    }
}
