using DocAppointment.Models;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocAppointment.Dtos
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        public ApplicationUser Client { get; set; }

        public Doctor Doctor { get; set; }

        public DateTime DateOfAppointment { get; set; }
    }
}