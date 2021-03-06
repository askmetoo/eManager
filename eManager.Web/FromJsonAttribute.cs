﻿using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace eManager.Web
{
    public class FromJsonAttribute : CustomModelBinderAttribute
    {
        private readonly static JavaScriptSerializer serializer = new JavaScriptSerializer();

        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }

        private class JsonModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                try
                {
                    var stringified = controllerContext.HttpContext.Request[bindingContext.ModelName];
                    if (string.IsNullOrEmpty(stringified))
                        return null;
                    return serializer.Deserialize(stringified, bindingContext.ModelType);
                }
                catch(Exception ex)
                {
                    //TODO: Handle specific exceptions
                    return null;
                }
            }
        }
    }
}