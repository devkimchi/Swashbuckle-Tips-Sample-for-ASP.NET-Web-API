using Ploeh.AutoFixture;

using Swashbuckle.Examples;

namespace SwashbuckleAspNetTipsSample.ApiApp.Examples
{
    /// <summary>
    /// This represents the example entity to be used for Swagger.
    /// </summary>
    /// <typeparam name="T">Type of model.</typeparam>
    public abstract class ModelExample<T> : IExamplesProvider where T : class
    {
        private readonly IFixture _fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelExample{T}"/> class.
        /// </summary>
        protected ModelExample()
        {
            this._fixture = new Fixture();
        }

        /// <inheritdoc />
        public virtual object GetExamples()
        {
            return this._fixture.Create<T>();
        }
    }
}