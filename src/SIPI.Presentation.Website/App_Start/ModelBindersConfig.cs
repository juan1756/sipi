using System;

namespace SIPI.Presentation.Website
{
    public class ModelBindersConfig
    {
        public static void RegisterModelBinders()
        {
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime), new ModelBinders.DateModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTime?), new ModelBinders.DateModelBinder());
        }
    }
}