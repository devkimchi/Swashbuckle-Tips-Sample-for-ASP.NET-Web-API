using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SwashbuckleAspNetTipsSample.ApiApp.Models
{
    /// <summary>
    /// This represents the response model entity for value.
    /// </summary>
    [XmlRoot("response")]
    public class ValueResponseModel
    {
        /// <summary>
        /// Gets or sets the <see cref="ValueReference"/> instance.
        /// </summary>
        [Required]
        [XmlElement("value")]
        public ValueReference Value { get; set; }
    }
}