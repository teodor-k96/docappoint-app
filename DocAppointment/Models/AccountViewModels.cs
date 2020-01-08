using DocAppointment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Моля, въведете имейл!")]
        [EmailAddress(ErrorMessage = "Форматът на имейла е невалиден!")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля, въведете вашите имена!")]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Моля, изберете пол!")]
        [Display(Name = "Пол")]
        public int? GenderId { get; set; }

        public List<Gender> Genders { get; set; }

        [Required(ErrorMessage = "Моля, въведете дата на раждане!")]
        [Display(Name = "Дата на раждане")]
        [DataType(DataType.Date)]
        [Min18Age]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Осигурен от НЗОК?")]
        public bool IsSecuredByNHIF { get; set; }

        [Display(Name = "Изберете профилна снимка:")]
        public byte[] UserPhoto { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Моля, въведете имейл!")]
        [EmailAddress(ErrorMessage = "Форматът на имейла е невалиден!")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Моля, въведете имейл!")]
        [Display(Name = "Имейл")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля, въведете парола!")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Моля, въведете имейл!")]
        [EmailAddress(ErrorMessage = "Форматът на имейла е невалиден!")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля, въведете парола!")]
        [StringLength(100, ErrorMessage = "Парола трябва да бъде дълга поне {2} символа!", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Паролата трябва да съдържа поне 1 главна буква, 1 малка буква и 1 цифра!")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете паролата")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Моля, въведете вашите имена!")]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Моля, изберете пол!")]
        [Display(Name = "Пол")]
        public int? GenderId { get; set; }

        public List<Gender> Genders { get; set; }

        [Required(ErrorMessage = "Моля, въведете дата на раждане!")]
        [Display(Name = "Дата на раждане")]
        [DataType(DataType.Date)]
        [Min18Age]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Осигурен от НЗОК?")]
        public bool IsSecuredByNHIF { get; set; }

        [Display(Name = "Изберете профилна снимка:")]
        public byte[] UserPhoto { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля, въведете новата парола!")]
        [StringLength(100, ErrorMessage = "Парола трябва да бъде дълга поне {2} символа!", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Паролата трябва да съдържа поне 1 главна буква, 1 малка буква и 1 цифра!")]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете новата парола")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Моля, въведете имейл!")]
        [EmailAddress(ErrorMessage = "Форматът на имейла е невалиден!")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}