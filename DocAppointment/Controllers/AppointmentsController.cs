using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DocAppointment.Models;

namespace DocAppointment.Controllers
{
    public class AppointmentsController : ApplicationBaseController
    {
        private ApplicationDbContext _context; // това е конвенция, с чрез този field достъпваме базата данни

        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Appointments
        [Authorize]
        public ActionResult NewAppointment(int id)
        {
            var doctor = _context.Doctors.Include(c => c.Specialty).Include(c => c.City).Single(c => c.Id == id);

            if (doctor == null)
                return HttpNotFound();

            var viewModel = new Appointment
            {
                Doctor = doctor
                
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult SaveNewAppointment(Appointment appointment)
        {
            if (!ModelState.IsValidField("DateOfAppointment"))
            {
                var viewModel = new Appointment
                {
                    Doctor = appointment.Doctor
                };

                return View("NewAppointment", viewModel);
            }

            if (appointment.AppointmentId == 0)
            {
                var doctor = _context.Doctors.Include(c => c.Specialty).Include(c => c.City).Single(c => c.Id == appointment.Doctor.Id);

                string userId = User.Identity.GetUserId();

                if (userId == null)
                    return HttpNotFound();

                var currentUser = _context.Users.Where(x => x.Id == userId).FirstOrDefault();

                appointment.Doctor = doctor;
                appointment.Client = currentUser;

                _context.Appointments.Add(appointment);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Doctors", new { message = "Успешно запазихте час!" });
        }

        [Authorize]
        public ActionResult AllAppointmentsByUserId()
        {
            string userId = User.Identity.GetUserId();

            if (userId == null)
                return HttpNotFound();

            ViewBag.currentUserId = userId;
            return View();
        }
    }
}