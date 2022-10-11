using System.Net;

namespace Core.Application.Exceptions
{
    public abstract class DataValidationException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public DataValidationException(string message) : base(message) { }
    }
}
