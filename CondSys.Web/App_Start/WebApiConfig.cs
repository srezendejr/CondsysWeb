using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace CondSys.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator());
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}/{id2}", new { id = RouteParameter.Optional, id2 = RouteParameter.Optional });

            //config.Routes.MapHttpRoute(
            //    name: "Moradores",
            //    routeTemplate: "api/{controller}/BuscarMoradoresContingencia/{id}",
            //    defaults: new { controller = "Default", action = "BuscarMoradoresContingencia", id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Visitantes",
            //    routeTemplate: "api/{controller}/BuscarVisitantesContigencia/{id}",
            //    defaults: new {controller = "Default", action= "BuscarVisitantesContigencia", id = RouteParameter.Optional }
            //);
            ((Newtonsoft.Json.Serialization.DefaultContractResolver)config.Formatters.JsonFormatter.SerializerSettings.ContractResolver).IgnoreSerializableAttribute = true;
        }
    }
}
