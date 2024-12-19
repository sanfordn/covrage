using Covrage;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace Example.API.ModelBinders
{
    public class PolicyModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var policyJson = bindingContext.HttpContext.Request.Body;
            using var reader = new StreamReader(policyJson);
            var json = await reader.ReadToEndAsync();
            string? policyType;
            try
            {
                policyType = JsonDocument.Parse(json).RootElement.GetProperty("PolicyType").GetString();
            }
            catch (KeyNotFoundException)
            {
                try
                {
                    policyType = JsonDocument.Parse(json).RootElement.GetProperty("policyType").GetString();
                }
                catch (KeyNotFoundException)
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                    return;
                }
            }


            Policy? policy;
            try
            {
                policy = (Policy?)JsonSerializer.Deserialize(json, Type.GetType($"Example.API.Domain.Policies.{policyType}"));
            }
            catch (JsonException)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            if (policy == null)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            bindingContext.Result = ModelBindingResult.Success(policy);
        }
    }
}
