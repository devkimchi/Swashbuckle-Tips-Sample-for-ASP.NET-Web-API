using System;
using System.Collections.Generic;

namespace SwashbuckleAspNetTipsSample.ApiApp.OperationFilters
{
    /// <summary>
    /// This represents the attribute entity for the "produces" field in Swagger definitions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerProducesAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerProducesAttribute"/> class.
        /// </summary>
        /// <param name="contentTypes">List of content types to produce.</param>
        public SwaggerProducesAttribute(params string[] contentTypes)
        {
            this.ContentTypes = contentTypes;
        }

        /// <summary>
        /// Gets the content type.
        /// </summary>
        public IEnumerable<string> ContentTypes { get; }
    }
}