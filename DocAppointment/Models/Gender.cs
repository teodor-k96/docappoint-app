using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocAppointment.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string GenderName { get; set; }
    }
}