using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FilePro.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string NoPeg { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
