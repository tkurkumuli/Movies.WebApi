using System.Net;

namespace Core.Application.Exceptions
{
    public class DataAlreadyExistsException : DataValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public DataAlreadyExistsException(string message) : base(message) { }
    }
}
