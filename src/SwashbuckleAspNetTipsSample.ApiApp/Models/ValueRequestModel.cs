using System;
using System.ComponentModel.DataAnnotations;

namespace SwashbuckleAspNetTipsSample.ApiApp.Models
{
    /// <summary>
    /// This represents the request model entity for value.
    /// </summary>
    public class ValueRequestModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is valid or not.
        /// </summary>
        [Required]
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the value was added.
        /// </summary>
        [Required]
        public DateTimeOffset AddedOn { get; set; }
    }
}