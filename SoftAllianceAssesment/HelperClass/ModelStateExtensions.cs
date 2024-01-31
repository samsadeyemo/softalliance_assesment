using Microsoft.AspNetCore.Mvc.ModelBinding;
using SoftAllianceAssesment.Models.ResponseModels;

namespace SoftAllianceAssesment.HelperClass
{
    public static class ModelStateExtensions
    {
        public static GenericResponseModel GetErrorMessages(this ModelStateDictionary dictionary)
        {
            var messages = string.Join(", ", dictionary
                                      .SelectMany(x => x.Value.Errors)
                                      .Select(x => x.ErrorMessage));
            return new GenericResponseModel { isSuccess = false, message = messages };


        }
    }
}
