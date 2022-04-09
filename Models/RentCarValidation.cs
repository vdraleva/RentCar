using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class RentCarValidation : IValidatableObject
    {
        [Required(ErrorMessage = "The start date is required")]
        [Display(Name = "Start Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Start_Date { get; set; }

        [Required(ErrorMessage = "The end date is required")]
        [Display(Name = "End Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime End_Date { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Owner { get; set; }
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (End_Date < Start_Date)
            {
                yield return new ValidationResult("EndDate must be greater than StartDate");
            }
        }
    }
}