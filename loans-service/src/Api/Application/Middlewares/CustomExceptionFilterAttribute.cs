using LoanService.Api.Application.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Api.Application
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var result = new ErrorDto("UnhandledError", context.Exception.Message);
            context.Result = new ObjectResult(result);

        }
    }
}