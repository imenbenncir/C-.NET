#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        
        [Required(ErrorMessage = "Chef name is required.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Chef age is required.")]
        [DataType(DataType.Date)]
        [PastDate(ErrorMessage = "Date of birth must be in the past.")]
        [MinimumAge(18, ErrorMessage = "Chef must be at least 18 years old.")]
        public DateTime DateOfBirth { get; set; }

        // Calculated property for age
        public int Age { get { return CalculateAge(DateOfBirth); } }

        // Navigation property for dishes
        public List<Dish> Dishes { get; set; } = new List<Dish>();

        // Helper method to calculate age based on DateOfBirth
        public int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            return age;
        }
    }

    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date of birth is required.");
            }

            DateTime birthDate = (DateTime)value;

            if (birthDate >= DateTime.Now)
            {
                return new ValidationResult("Date of birth must be in the past.");
            }

            return ValidationResult.Success;
        }
    }

    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Age is required.");
            }

            if (value is not DateTime dateOfBirth)
            {
                return new ValidationResult("Invalid date of birth.");
            }

            int age = CalculateAge(dateOfBirth);

            if (age < _minimumAge)
            {
                return new ValidationResult($"Chef must be at least {_minimumAge} years old.");
            }

            return ValidationResult.Success;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (DateTime.Today < dateOfBirth.AddYears(age)) age--;
            return age;
        }
    }
}