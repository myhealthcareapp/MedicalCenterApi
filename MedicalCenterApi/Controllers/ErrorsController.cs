using Domain.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MedicalCenterApi.Controllers
{

    [ApiController]
    public class ErrorsController(ILogger<ErrorsController> logger) : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            
            if (exception != null && exception is ApiException)
            {
                ApiException apiException = (ApiException)exception;
                logger.LogError($"Error Occured: StatusCode: {apiException.StatusCode} - Message: {exception.Message}");
                return Problem(title: exception.Message, statusCode: apiException.StatusCode);
            }
            logger.LogError($"Error Occured: StatusCode: {StatusCodes.Status500InternalServerError} - Message: {exception?.Message}");
            return Problem(title: "There is some unexpected error. Our expert team is on to it. Please stay tuned.", statusCode: StatusCodes.Status500InternalServerError);
           
        }
    }
}
