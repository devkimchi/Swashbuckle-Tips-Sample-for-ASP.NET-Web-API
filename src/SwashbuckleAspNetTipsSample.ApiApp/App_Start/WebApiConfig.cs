using System.Web.Http;

using Autofac;
using Autofac.Integration.WebApi;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Owin;

using Swashbuckle.Application;

namespace SwashbuckleAspNetTipsSample.ApiApp
{
    /// <summary>
    /// This represents the configuration entity for Web API.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Configures the Web API application.
        /// </summary>
        /// <param name="app"><see cref="IAppBuilder"/> instance.</param>
        /// <param name="container"><see cref="IContainer"/> instance.</param>
        public static void Register(IAppBuilder app, IContainer container)
        {
            var settings = new JsonSerializerSettings()
                               {
                                   ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                   Formatting = Formatting.Indented,
                                   Converters = { new StringEnumConverter() },
                                   NullValueHandling = NullValueHandling.Ignore,
                                   MissingMemberHandling = MissingMemberHandling.Ignore
                               };
            var config = new HttpConfiguration
                             {
                                 DependencyResolver = new AutofacWebApiDependencyResolver(container)
                             };
            config.Formatters.JsonFormatter.SerializerSettings = settings;

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute(
                name: "Swagger",
                routeTemplate: "swagger/ui",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));

            // Swagger
            SwaggerConfig.Register(config);

            // Middlewares
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
