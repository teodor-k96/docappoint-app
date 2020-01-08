using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocAppointment.Models
{
    public class EditUserInfoViewModel
    {
        public List<Gender> Genders { get; set; }

        public ApplicationUser User { get; set; }

        public byte[] UserPhoto { get; set; }
    }
}