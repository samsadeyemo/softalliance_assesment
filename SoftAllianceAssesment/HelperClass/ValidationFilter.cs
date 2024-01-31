using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SoftAllianceAssesment.HelperClass
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before contrller

            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage).ToArray());

                var errorResponse = new MyErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new MyErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorResponse.Error.Add(errorModel);
                    }

                    context.Result = new BadRequestObjectResult(errorResponse);
                    return;
                }

                await next();

                //after controller  
            }
        }
    }
    public class MyErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
    public class MyErrorResponse
    {
        public List<MyErrorModel> Error { get; set; } = new List<MyErrorModel>();
        public bool Successful { get; set; }
    }
}