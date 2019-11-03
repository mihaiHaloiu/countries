using System.Web.Http;
using System.Web.Http.Cors;
using Api.Bll.Mappers;
using Api.Bll.Services;
using APi.Dal.Repositories;
using Unity;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var container = new UnityContainer();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<ICountryRepository, CountryRepository>();
            container.RegisterType<ICountryMapper, CountryMapper>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
