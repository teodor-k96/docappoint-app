using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocAppointment.Dtos
{
    public class DoctorDto   // only primitive types or dtos
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        //--> City
        public CityDto City { get; set; }

        public int? CityId { get; set; }
        //--<

        public string AddressLine { get; set; }

        //--> Specialty
        public SpecialtyDto Specialty { get; set; }

        public int? SpecialtyId { get; set; }
        //--<

        public bool WorksWithNHIF { get; set; }

        public string DoctorInfo { get; set; }

        public DateTime WorktimeStart { get; set; }

        public DateTime WorktimeEnd { get; set; }

        public decimal? PriceForExamination { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}