using System.ComponentModel.DataAnnotations;

namespace MVCECommerce.Models
{
    public class ResetPasswordViewModel
    {
        [Display(Name ="E-Posta")]
        [Required(ErrorMessage ="{0} Alanı boş bırakılamaz")]
        public string UserName { get; set; }

    }
}
