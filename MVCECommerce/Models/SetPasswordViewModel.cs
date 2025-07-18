using System.ComponentModel.DataAnnotations;

namespace MVCECommerce.Models
{
    public class SetPasswordViewModel
    {

        public Guid? Id { get; set; }
        public string? Token { get; set; }

        [Display(Name ="Yeni parola")]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Yeni parola Tekrar")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="{0} ve {1} alanı aynı olmalıdır")]
        public string? PasswordCheck { get; set; }

    }
}
