using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Web.Models;

namespace eManager.Web.ViewModels
{
    public class GenericModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var processName = bindingContext.ValueProvider.GetValue("process");
            if (processName == null)
            {
                throw new Exception("Impossible to instantiate a model. The \"typeName\" query string parameter was not provided.");
            }

            if (processName.Equals("Department"))
            {
            }
            
            var type = typeof(Department);
            //var type = Type.GetType("eManager.Domain."+ processName.AttemptedValue);
            //var type = Type.GetType(
            //    (string)processName.ConvertTo(typeof(string)),
            //    true
            //);
            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
            return model;
        }
    }
}