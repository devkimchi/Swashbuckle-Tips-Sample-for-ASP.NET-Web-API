using System;

using Owin;

namespace SwashbuckleAspNetTipsSample.ApiApp
{
    /// <summary>
    /// This represents the entity to start up Web API.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures Web API app.
        /// </summary>
        /// <param name="app"><see cref="IAppBuilder"/> instance.</param>
        public void Configuration(IAppBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var container = DependencyConfig.Register(app);

            WebApiConfig.Register(app, container);
        }
    }
}