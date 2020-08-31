using Annexio.App_Start;
using Annexio.Controllers.HttpClients;
using Annexio.CountiresUriBuilder;
using Annexio.Repository.CountriesUriBuilder;
using Annexio.Repository.Manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.AspNet.Mvc;

namespace Annexio
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ICountriesHttpClient, CountriesHttpClient>();
            container.RegisterType<IRegionsHttpClient, RegionsHttpClient>();
            container.RegisterType<ISubregionsHttpClient, SubregionsHttpClient>();
            container.RegisterType<ICountriesUriBuilder, CountriesUriBuilder>();
            container.RegisterType<ICountriesManager, CountriesManager>();
            container.RegisterType<IRegionsManager, RegionsManager>();
            container.RegisterType<ISubregionsManager, SubregionsManager>();

            config.DependencyResolver = new UnityResolver(container);

            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
            );
        }
    }
}
