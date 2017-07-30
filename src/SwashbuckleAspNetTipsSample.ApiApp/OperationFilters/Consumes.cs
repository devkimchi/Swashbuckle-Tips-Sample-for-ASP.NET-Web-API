using System.Linq;
using System.Web.Http.Description;

using Swashbuckle.Swagger;

namespace SwashbuckleAspNetTipsSample.ApiApp.OperationFilters
{
    /// <summary>
    /// This represents the filter entity for the "consumes" field in Swagger definitions.
    /// </summary>
    public partial class Consumes : IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var attribute = apiDescription.GetControllerAndActionAttributes<SwaggerConsumesAttribute>().SingleOrDefault();
            if (attribute == null)
            {
                return;
            }

            operation.consumes.Clear();
            operation.consumes = attribute.ContentTypes.ToList();
        }
    }
}