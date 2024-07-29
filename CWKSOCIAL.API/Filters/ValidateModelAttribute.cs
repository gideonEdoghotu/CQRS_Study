using CWKSOCIAL.API.Contracts.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CWKSOCIAL.API.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var apiError = new ErrorResponse();
                apiError.StatusCode = 400;
                apiError.StatusPhrase = "Bad Request";
                apiError.Timestamp = DateTime.Now;
                var errors = context.ModelState.AsEnumerable();

                foreach (var error in errors)
                {
                    foreach (var inner in error.Value.Errors)
                    {
                        apiError.Errors.Add(inner.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(apiError);
            }
        }

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (!context.ModelState.IsValid)
        //    {
        //        var apiError = new ErrorResponse();
        //        apiError.StatusCode = 400;
        //        apiError.StatusPhrase = "Bad Request";
        //        apiError.Timestamp = DateTime.Now;
        //        var errors = context.ModelState.AsEnumerable();

        //        foreach (var error in errors)
        //        {
        //            apiError.Errors.Add(error.Value.ToString());
        //        }

        //        context.Result = new NotFoundObjectResult(apiError);
        //    }
        //}
    }
}
