namespace System.Web.Mvc
{
    public static class HtmlHelperModelExtensions
    {
        public static HtmlHelper<TInnerModel> ToInnerModel<TModel, TInnerModel>(this HtmlHelper<TModel> htmlHelper, Func<TModel, TInnerModel> modelExpression)
        {
            var model = htmlHelper.ViewDataContainer.ViewData.Model;
            if (model == null)
            {
                model = Activator.CreateInstance<TModel>();
            }
            var innerModel = modelExpression.Invoke((TModel)model);
            return htmlHelper.ToModel(innerModel);
        }

        private static HtmlHelper<TModel> ToModel<TModel>(this HtmlHelper htmlHelper, TModel model = default(TModel), bool defaultModel = false)
        {
            return new HtmlHelper<TModel>(htmlHelper.ViewContext, new CustomViewDataContainer<TModel>(htmlHelper.ViewData, model, defaultModel));
        }

        private class CustomViewDataContainer<TModel> : IViewDataContainer
        {
            public ViewDataDictionary ViewData { get; set; }

            public CustomViewDataContainer(ViewDataDictionary initialData)
                : this(initialData, default(TModel)) { }

            public CustomViewDataContainer(ViewDataDictionary initialData, TModel model = default(TModel), bool defaultModel = false)
            {
                if (defaultModel)
                {
                    ViewData = new ViewDataDictionary(Activator.CreateInstance<TModel>());
                }
                else
                {
                    ViewData = new ViewDataDictionary(model);
                }
                foreach (var item in initialData)
                {
                    ViewData.Add(item);
                }
            }
        }
    }
}