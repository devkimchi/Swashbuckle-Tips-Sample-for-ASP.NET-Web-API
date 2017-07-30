using Autofac;

using Owin;

namespace SwashbuckleAspNetTipsSample.ApiApp
{
    /// <summary>
    /// This represents the configuration entity for dependencies.
    /// </summary>
    public static class DependencyConfig
    {
        /// <summary>
        /// Registers all dependencies.
        /// </summary>
        /// <param name="app"><see cref="IAppBuilder"/> instance.</param>
        /// <returns>Returns the <see cref="IContainer"/> instance.</returns>
        public static IContainer Register(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            var container = builder.Build();

            return container;
        }
    }
}