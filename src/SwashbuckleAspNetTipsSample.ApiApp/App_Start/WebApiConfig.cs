using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
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
                                   // Add JSON serialiser settings to support camelCasing.
                                   ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                   Formatting = Formatting.Indented,
                                   Converters = { new StringEnumConverter() },
                                   NullValueHandling = NullValueHandling.Ignore,
                                   MissingMemberHandling = MissingMemberHandling.Ignore
                               };

            var config = new HttpConfiguration
                             {
                                 DependencyResolver = new AutofacWebApiDependencyResolver(container),
                             };

            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings = settings;
            jsonFormatter.SupportedMediaTypes.Clear();
            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            var xmlFormatter = config.Formatters.XmlFormatter;

            // Starts using XmlSerialiser rather than DataContractSerializer.
            xmlFormatter.UseXmlSerializer = true;
            xmlFormatter.SupportedMediaTypes.Clear();
            xmlFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));

            config.Formatters.Clear();
            config.Formatters.AddRange(new List<MediaTypeFormatter>() { jsonFormatter, xmlFormatter });

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "RootRedirectToSwagger",
                routeTemplate: string.Empty,
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));
            config.Routes.MapHttpRoute(
                name: "SwaggerRedirect",
                routeTemplate: "swagger",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));
            config.Routes.MapHttpRoute(
                name: "SwaggerUiRedirect",
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
