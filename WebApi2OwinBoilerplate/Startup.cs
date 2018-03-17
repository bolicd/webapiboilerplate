using Newtonsoft.Json.Serialization;
using Owin;
using StructureMap;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApi2OwinBoilerplate.DependencyResolution;

namespace WebApi2OwinBoilerplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = WebApiConfiguration();
            ConfigureStructureMap(config);
            appBuilder.UseWebApi(config);
        }

        private static void ConfigureStructureMap(HttpConfiguration config)
        {
            //setting up IoC container - StructureMap
            IContainer container = IoC.Initialize();
            container.AssertConfigurationIsValid();
            Debug.WriteLine(container.WhatDoIHave());
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
        }

        private static HttpConfiguration WebApiConfiguration()
        {
            HttpConfiguration config = new HttpConfiguration();
            
            // enable attribute routing
            config.MapHttpAttributeRoutes();

            //set default routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //return camelcase json
            var JsonFormater = config.Formatters.JsonFormatter;
            JsonFormater.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));


            return config;
        }
    }

    ////enforcing lowercase routes
    public class LowercaseRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var path = httpContext.Request.Url.AbsolutePath;
            return path.Equals(path.ToLowerInvariant(), StringComparison.InvariantCulture);
        }
    }
}
