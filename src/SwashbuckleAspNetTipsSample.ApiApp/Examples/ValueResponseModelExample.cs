using System;

using Swashbuckle.Examples;

using SwashbuckleAspNetTipsSample.ApiApp.Models;

namespace SwashbuckleAspNetTipsSample.ApiApp.Examples
{
    /// <summary>
    /// This represents the example entity to be used for Swagger.
    /// </summary>
    public class ValueResponseModelExample : IExamplesProvider
    {
        /// <inheritdoc />
        public virtual object GetExamples()
        {
            var value = new ValueReference()
                            {
                                Id = Guid.NewGuid(),
                                Name = "value name",
                                Value = 123,
                                IsValid = true,
                                AddedOn = DateTimeOffset.Now
                            };
            var model = new ValueResponseModel() { Value = value };

            return model;
        }
    }
}