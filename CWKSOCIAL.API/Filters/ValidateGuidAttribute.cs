using CWKSOCIAL.API.Contracts.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CWKSOCIAL.API.Filters
{
    public class ValidateGuidAttribute : ActionFilterAttribute
    {
        //private readonly List<string> _keys;
        private readonly string _key;
        //public ValidateGuidAttribute(params string[] keys)
        //{
        //    _keys = keys.ToList();
        //}

        public ValidateGuidAttribute(string key)
        {
            _key = key;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue(_key, out var value)) return;
            if (!Guid.TryParse(value?.ToString(), out var guid)) return;

            var apiError = new ErrorResponse
            {
                StatusCode = 400,
                StatusPhrase = "Bad request",
                Timestamp = DateTime.Now
            };
            apiError.Errors.Add($"The identifier for {_key} is not a correct GUID format");
            context.Result = new ObjectResult(apiError);
        }

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    bool hasError = false;
        //    var apiError = new ErrorResponse();
        //    _keys.ForEach(k =>
        //    {
        //        if (!context.ActionArguments.TryGetValue(k, out var value)) return;
        //        if (!Guid.TryParse(value?.ToString(), out var guid))
        //        {
        //            hasError = true;
        //            apiError.Errors.Add($"The identifier for {k} is not a correct GUID format");
        //        }
        //    });

        //    if (hasError)
        //    {
        //        apiError.StatusCode = 400;
        //        apiError.StatusPhrase = "Bad request";
        //        apiError.Timestamp = DateTime.Now;
        //        context.Result = new ObjectResult(apiError);
        //    }
        //}
    }
}
