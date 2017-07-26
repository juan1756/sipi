using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.ActionResults
{
    public class JsonNetResult : JsonResult
    {
        // http://labs.bjfocus.co.uk/2014/06/using-json-net-as-default-json-serializer-in-mvc/
        public JsonNetResult() 
            : base()
        {
            Settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include
            };

            Settings.Converters.Add(new StringEnumConverter());
        }

        public JsonSerializerSettings Settings { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data == null)
                return;

            response.ContentType = string.IsNullOrEmpty(ContentType) 
                ? "application/json" 
                : ContentType;

            var scriptSerializer = JsonSerializer.Create(Settings);
            scriptSerializer.Serialize(response.Output, Data);
        }
    }
}