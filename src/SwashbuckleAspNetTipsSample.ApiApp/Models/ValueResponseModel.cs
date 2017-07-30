using System.ComponentModel.DataAnnotations;

namespace SwashbuckleAspNetTipsSample.ApiApp.Models
{
    /// <summary>
    /// This represents the response model entity for value.
    /// </summary>
    public class ValueResponseModel
    {
        /// <summary>
        /// Gets or sets the <see cref="ValueReference"/> instance.
        /// </summary>
        [Required]
        public ValueReference Value { get; set; }
    }
}