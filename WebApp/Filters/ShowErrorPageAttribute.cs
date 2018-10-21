using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Filters
{
    public class ShowErrorPageAttribute : Attribute, IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ShowErrorPageAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            var errorView = new ViewResult
            {
                ViewName = "Error"
            };

            errorView.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);

            errorView.ViewData.Add("ErrorMessage", ex.Message);

            context.Result = errorView;
        }
    }
}