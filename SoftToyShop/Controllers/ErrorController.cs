using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftToyShop.Constants;

namespace SoftToyShop.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case ResponseCode._notFoundException:
                    ViewBag.ErrorMessage = ErrorMessage._notFoundException;
                    _logger.LogWarning($"{ErrorMessage._notFoundException} error occured. Path is " +
                        $"{statusCodeResult.OriginalPath} and QueryString is {statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"The path {exceptionDetails.Path} throw an exception {exceptionDetails.Error.Message}");

            return View();
        }
    }
}
