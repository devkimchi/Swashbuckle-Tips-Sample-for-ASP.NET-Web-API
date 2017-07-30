using System;
using System.Collections.Generic;

namespace SwashbuckleAspNetTipsSample.ApiApp.OperationFilters
{
    /// <summary>
    /// This represents the attribute entity for the "consumes" field in Swagger definitions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerConsumesAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerConsumesAttribute"/> class.
        /// </summary>
        /// <param name="contentTypes">List of content types to consume.</param>
        public SwaggerConsumesAttribute(params string[] contentTypes)
        {
            this.ContentTypes = contentTypes;
        }

        /// <summary>
        /// Gets the content type.
        /// </summary>
        public IEnumerable<string> ContentTypes { get; }
    }
}