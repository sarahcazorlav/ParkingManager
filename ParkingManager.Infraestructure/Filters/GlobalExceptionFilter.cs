using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingManager.Core.Exceptions;
using System.Net;

namespace ParkingManager.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessException businessException)
            {
                var validation = new
                {
                    Status = 400,
                    Title = "Error de negocio",
                    Detail = businessException.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var error = new
                {
                    Status = 500,
                    Title = "Error interno del servidor",
                    Detail = context.Exception.Message
                };

                context.Result = new ObjectResult(new { errors = new[] { error } })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            context.ExceptionHandled = true;
        }
    }
}