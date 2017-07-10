using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.ModelBinders
{
    public class DateModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var datetime = new DateTime();
            var success = DateTime.TryParse(value.AttemptedValue, Thread.CurrentThread.CurrentCulture.DateTimeFormat, DateTimeStyles.None, out datetime);

            if (success)
                return datetime;
            else
                return null;
        }
    }
}