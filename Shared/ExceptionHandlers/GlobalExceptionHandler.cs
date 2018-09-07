using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Shared.Logger;

namespace Shared.ExceptionHandlers
{
    public class GlobalExceptionHandler: ExceptionHandler
    {
        private readonly GlobalLogger _logger = new GlobalLogger();
        public override void Handle(ExceptionHandlerContext context)
        {
            // Access Exception using context.Exception;  
            const string errorMessage = "An unexpected error occured";
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    Message = errorMessage
                });
            _logger.log.Error("Exception Occurred: " + context.Exception.ToString());
            response.Headers.Add("X-Error", errorMessage);
            context.Result = new ResponseMessageResult(response);
        }
    }
}
