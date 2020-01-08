using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocAppointment.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required]
        public ApplicationUser Client { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        [Display(Name = "Дата и час за преглед")]
        [Required(ErrorMessage = "Моля, изберете дата и час за преглед!")]
        [DataType(DataType.DateTime, ErrorMessage = "Стойността трябва да бъде дата!")]
        public DateTime DateOfAppointment { get; set; }

    }
}