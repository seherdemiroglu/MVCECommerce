using Microsoft.AspNetCore.Mvc;
using MVCECommerceData;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerce.Models
{
    public class RegisterViewModel
    {
        [Display(Name ="E-Posta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz!")]
        public string? Username {  get; set; }

        [Display(Name = "Ad / Soyad")] //label içine de yazılabilir ama localization da pratik olacak
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public string? GivenName { get; set; }

        [Display(Name = "Cinsiyet")]
        public Genders Gender { get; set; }

        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public string? Password { get; set; }

        [Display(Name = "Parola Tekrar")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [Compare("Password",ErrorMessage ="{0} ile {1} alanı aynı olmalıdır")]
        public string? PasswordCheck { get; set; }
    }
}
