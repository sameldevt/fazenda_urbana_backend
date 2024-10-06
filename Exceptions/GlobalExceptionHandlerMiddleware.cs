using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Model.Common;

namespace Exceptions
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An internal server error occurred.";

            switch (exception)
            {
                case ResourceNotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case DatabaseManipulationException databaseManipulationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = databaseManipulationException.Message;
                    break;
                case InvalidCredentialsException invalidCredentialsException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = invalidCredentialsException.Message;
                    break;
                case UserAlreadyRegisteredException userAlreadyRegisteredException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = userAlreadyRegisteredException.Message;
                    break;
                default:
                    _logger.LogError(exception, "Unhandled exception occurred.");
                    break;
            }

            var response = new ApiResponse
            {
                StatusCode = (int)statusCode,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }

    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message) { }
    }

    public class DatabaseManipulationException : Exception
    {
        public DatabaseManipulationException(string message) : base(message) { }
    }

    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message) : base(message) { }
    }

    public class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException(string message) : base(message) { }
    }
}
