using System.ComponentModel.DataAnnotations;

namespace DojoSurveywithValidations.Models
{
    public class User
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(2, ErrorMessage = "The Name field must be at least 2 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Location field is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The Favorite Language field is required.")]
        public string FavLang { get; set; }

        [MinLength(20, ErrorMessage = "The Comment field must be at least 20 characters long.")]
        public string Comment { get; set; }
    }
}
