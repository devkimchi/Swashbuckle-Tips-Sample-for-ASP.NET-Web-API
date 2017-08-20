using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SwashbuckleAspNetTipsSample.ApiApp.Models
{
    /// <summary>
    /// This represents the request model entity for value.
    /// </summary>
    [XmlRoot("request")]
    public class ValueRequestModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Required]
        [XmlElement("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        [XmlElement("value")]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is valid or not.
        /// </summary>
        [Required]
        [XmlElement("isValid")]
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the value was added.
        /// </summary>
        [Required]
        [XmlElement("addedOn")]
        public DateTimeOffset AddedOn { get; set; }
    }
}