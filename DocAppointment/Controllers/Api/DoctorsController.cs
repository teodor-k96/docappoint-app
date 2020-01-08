using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using DocAppointment.Models;
using DocAppointment.Dtos;
using AutoMapper;

namespace DocAppointment.Controllers.Api
{
    public class DoctorsController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/doctors
        public IHttpActionResult GetDoctors(string query = null)
        {
            var doctorsQuery = _context.Doctors.Include(c => c.Specialty).Include(c => c.City);
            // the nav property has to be included(City, not CityId) !!

            if (!String.IsNullOrWhiteSpace(query))
                doctorsQuery = doctorsQuery.Where(c => c.FullName.Contains(query));

            var doctorDtos = doctorsQuery.ToList().Select(Mapper.Map<Doctor, DoctorDto>);

            return Ok(doctorDtos);
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageDoctors)]
        public void DeleteDoctor(int id)
        {
            var doctorInDb = _context.Doctors.SingleOrDefault(c => c.Id == id);

            if (doctorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Doctors.Remove(doctorInDb);
            _context.SaveChanges();
        }
    }
}
