using System;
using System.Collections.Generic;
using System.Linq;

using Swashbuckle.Swagger;

namespace SwashbuckleAspNetTipsSample.ApiApp.SchemaFilters
{
    /// <summary>
    /// This represents the schema filter entity for the request model classes.
    /// </summary>
    public class Requests : ISchemaFilter
    {
        private readonly IEnumerable<Type> _types;

        /// <summary>
        /// Initializes a new instance of the <see cref="Requests"/> class.
        /// </summary>
        /// <param name="types">List of types to consider in XML request payload.</param>
        public Requests(params Type[] types)
        {
            if (types == null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            this._types = types;
        }

        /// <inheritdoc />
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (!this._types.Contains(type))
            {
                return;
            }

            schema.xml = new Xml() { name = "request" };
        }
    }
}
