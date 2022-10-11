using System.Net;

namespace Core.Application.Exceptions
{
    public abstract class EntityValidationException : DataValidationException
    {
        public override HttpStatusCode StatusCode { get; }
        public EntityValidationException(string message) : base(message) { }
    }
}
