using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocAppointment.Models.ViewModels
{
    public class NewDoctorViewModel
    {
        public List<City> Cities { get; set; }

        public List<Specialty> Specialties { get; set; }

        public Doctor Doctor { get; set; }

        public byte[] DoctorPhoto { get; set; }
    }
}