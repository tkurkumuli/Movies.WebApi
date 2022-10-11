using System.Net;

namespace Core.Application.Exceptions
{
    public class DataNotFoundException : DataValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public DataNotFoundException(string message) : base(message) { }
    }
}
