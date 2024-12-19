using Covrage;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Example.API.ModelBinders
{
    public class PolicyModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Policy) || context.Metadata.ModelType.IsSubclassOf(typeof(Policy)))
            {
                return new BinderTypeModelBinder(typeof(PolicyModelBinder));
            }
            return null;
        }
    }
}
