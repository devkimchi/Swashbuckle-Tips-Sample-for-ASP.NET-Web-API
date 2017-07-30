using System.Linq;
using System.Web.Http.Description;

using Swashbuckle.Swagger;

namespace SwashbuckleAspNetTipsSample.ApiApp.OperationFilters
{
    /// <summary>
    /// This represents the filter entity for the "produces" field in Swagger definitions.
    /// </summary>
    public class Produces : IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var attribute = apiDescription.GetControllerAndActionAttributes<SwaggerProducesAttribute>().SingleOrDefault();
            if (attribute == null)
            {
                return;
            }

            operation.produces.Clear();
            operation.produces = attribute.ContentTypes.ToList();
        }
    }
}