using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace beflightsearch.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Flight name is required.")]
        [MaxLength(100, ErrorMessage = "Flight name cannot exceed 50 characters.")]

        public string FlightName { get; set; }

        public int AirlineId { get; set; }

        [Required(ErrorMessage = "Departure date and time are required.")]
        [CustomValidation(typeof(Flight), nameof(ValidateDepartureDate))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDateTime { get; set; }

        [Required(ErrorMessage = "Arrival date and time are required.")]
        [CustomValidation(typeof(Flight), nameof(ValidateArrivalDate))]
        [ValidateArrivalDateWithDepartureDate(ErrorMessage = "Arrival date cannot be before departure date.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDateTime { get; set; }

        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }
        public int Scales { get; set; }

        public static ValidationResult ValidateDepartureDate(DateTime departureDateTime, ValidationContext context)
        {
            if (departureDateTime.Date < DateTime.Now.Date)
            {
                return new ValidationResult("Departure date cannot be before the current day.");
            }

            return ValidationResult.Success;
        }

        public static ValidationResult ValidateArrivalDate(DateTime arrivalDateTime, ValidationContext context)
        {
            if (arrivalDateTime.Date < DateTime.Now.Date)
            {
                return new ValidationResult("Arrival date cannot be before the current day.");
            }

            return ValidationResult.Success;
        }

        public class ValidateArrivalDateWithDepartureDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var departureDate = (DateTime)validationContext.ObjectType.GetProperty("DepartureDateTime")?.GetValue(validationContext.ObjectInstance, null);
                var arrivalDate = (DateTime)value;

                if (arrivalDate < departureDate)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }
    }

}

