using CarAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarAssignment.Filters
{
    public class ValidateTypeCarAttribute:ActionFilterAttribute
    {
        private readonly IConfiguration _configuration;

        // inject configuration service
        public ValidateTypeCarAttribute(IConfiguration configuration) {
            _configuration = configuration;
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var types = _configuration.GetSection("CarTypes").Get<string[]>();

            var car = context.ActionArguments["car"] as Car;

            var checkType = types.FirstOrDefault(c=>c.Equals(car.Type));

            if (checkType is null || car is null)
            {
                //Short Circuit with BadRequest
                context.ModelState.AddModelError("Type", "Car Type is not exsist");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            // else will execute rest logic in action

        }
    }
}
