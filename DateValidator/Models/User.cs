#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;

public class User
{
   [Required]
   public string Name {get;set;}
   [Required(ErrorMessage = "The date is required.")]
   [FutureDate(ErrorMessage = "The date must be in the future.")]

   public DateTime DateOfBirth  { get; set; }
}

public class FutureDateAttribute : ValidationAttribute
{
   protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
   {
      if((DateTime?)value > DateTime.Now)
      {
            return new ValidationResult("Birthday must be in the past!");
      } else {
            return ValidationResult.Success;
      }
   }
}
