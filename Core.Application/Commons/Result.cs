namespace Core.Application.Commons
{
    public static class Result
    {
        public static object Failure(string titleText, int statusCode, string traceId, Exception exception) => new
        {
            title = titleText,
            status = statusCode,
            traceId = traceId,
            errors = new
            {
                messages = new string[] { exception.InnerException?.InnerException?.Message ?? exception.InnerException?.Message ?? exception.Message }
            }
        };

    }
}
