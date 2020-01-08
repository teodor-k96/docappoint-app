using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocAppointment.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [StringLength(70, ErrorMessage = "Името не трябва да превишава {0} символа!")]
        [Required(ErrorMessage = "Моля, въведете име на доктора!")]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        public City City { get; set; }

        [Required(ErrorMessage = "Моля, изберете град!")]
        [Display(Name = "Град")]
        public int? CityId { get; set; }

        [StringLength(100, ErrorMessage = "Адресът не трябва да превишава {0} символа!")]
        [Required(ErrorMessage = "Моля, въведете адрес!")]
        [Display(Name = "Адрес")]
        public string AddressLine { get; set; }

        public Specialty Specialty { get; set; }

        [Required(ErrorMessage = "Моля, изберете специалност!")]
        [Display(Name = "Специалност")]
        public int? SpecialtyId { get; set; }

        [Display(Name = "Работи ли с НЗОК?")]
        public bool WorksWithNHIF { get; set; }

        [StringLength(1024, ErrorMessage = "Описанието не трябва да превишава {0} символа!")]
        [Display(Name = "Информация за доктора")]
        public string DoctorInfo { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Начало на работния ден")]
        [Required(ErrorMessage = "Моля, въведете час за начало на работния ден на доктора!")]
        public DateTime? WorktimeStart { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Край на работния ден")]
        [Required(ErrorMessage = "Моля, въведете час за край на работния ден на доктора!")]
        public DateTime? WorktimeEnd { get; set; }

        [Display(Name = "Цена на преглед")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency, ErrorMessage = "Грешен формат за валута!")]
        [Range(0, 5000, ErrorMessage = "Цената трябва да е по-голяма или равна на 0, и не по-голяма от 5000!")]
        public decimal? PriceForExamination { get; set; }

        [Display(Name = "Изберете снимка на доктора:")]
        public byte[] DoctorPhoto { get; set; }
    }
}