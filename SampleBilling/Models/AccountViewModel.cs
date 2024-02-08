using System.ComponentModel.DataAnnotations;

namespace SampleBilling.Models
{
    public class AccountViewModel
    {

        [Required(ErrorMessage ="UserName is required")]
        [DataType(DataType.EmailAddress)]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Rememer me")]
        public bool RememberMe { get; set; }
    }
}
