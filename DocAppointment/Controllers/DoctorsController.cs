using DocAppointment.Models;
using DocAppointment.Models.ViewModels;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace DocAppointment.Controllers
{
    public class DoctorsController : ApplicationBaseController
    {
        private ApplicationDbContext _context; // това е конвенция, с чрез този field достъпваме базата данни

        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Doctors
        public ActionResult Index(string message)
        {
            if (User.IsInRole(RoleName.CanManageDoctors))
            {
                ViewBag.newDocMessage = message;
                return View();
            }

            ViewBag.successfulAppoint = message;
            return View("ReadOnlyIndex");
        }

        [Authorize(Roles = RoleName.CanManageDoctors)]
        public ActionResult NewDoctor()
        {
            var cities = _context.Cities.ToList();
            var specialties = _context.Specialties.ToList();

            var viewModel = new NewDoctorViewModel
            {
                Doctor = new Doctor(),
                Cities = cities,
                Specialties = specialties
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNewDoctor([Bind(Exclude = "DoctorPhoto")]Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewDoctorViewModel
                {
                    Doctor = doctor,
                    Cities = _context.Cities.ToList(),
                    Specialties = _context.Specialties.ToList()
                };

                return View("NewDoctor", viewModel);

            }

            string saveMessage = "";

            if (doctor.Id == 0)
            {
                _context.Doctors.Add(doctor);
                saveMessage = "Добавихте нов запис в таблицата!";
            }
            else
            {
                var doctorInDb = _context.Doctors.Single(c => c.Id == doctor.Id);

                doctorInDb.FullName = doctor.FullName;
                doctorInDb.CityId = doctor.CityId;
                doctorInDb.AddressLine = doctor.AddressLine;
                doctorInDb.SpecialtyId = doctor.SpecialtyId;
                doctorInDb.WorksWithNHIF = doctor.WorksWithNHIF;
                doctorInDb.DoctorInfo = doctor.DoctorInfo;
                doctorInDb.WorktimeStart = doctor.WorktimeStart;
                doctorInDb.WorktimeEnd = doctor.WorktimeEnd;
                doctorInDb.PriceForExamination = doctor.PriceForExamination;

                // To convert the doctor uploaded Photo as Byte Array before save to DB    
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["DoctorPhoto"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }

                doctorInDb.DoctorPhoto = imageData;

                saveMessage = "Успешно направени промени!";
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Doctors", new { message = saveMessage });
        }

        [Authorize]
        public ActionResult EditDoctor(int id)
        {
            var doctor = _context.Doctors.Include(c => c.Specialty).Include(c => c.City).SingleOrDefault(c => c.Id == id);

            if (doctor == null)
                return HttpNotFound();

            var viewModel = new NewDoctorViewModel
            {
                Doctor = doctor,
                Cities = _context.Cities.ToList(),
                Specialties = _context.Specialties.ToList()
            };

            if (User.IsInRole(RoleName.CanManageDoctors))
            {
                return View("NewDoctor", viewModel);
            };

            string userId = User.Identity.GetUserId();

            if (userId == null)
                return HttpNotFound();
            
            // get the current user
            var currentUser = _context.Users.Where(x => x.Id == userId).FirstOrDefault();

            var isSecuredByNHIF = currentUser.IsSecuredByNHIF;

            ViewBag.isSecured = isSecuredByNHIF;
            return View("ReadOnlyDoctor", viewModel);
        }

        public FileContentResult DoctorsPhoto(int id)
        {
            var doctor = _context.Doctors.Where(x => x.Id == id).FirstOrDefault();

            if (doctor.DoctorPhoto == null || doctor.DoctorPhoto.Count() == 0)
            {
                string fileName = HttpContext.Server.MapPath(@"~/Content/images/unknownDoctor.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");

            }
            // to get the user details to load user Image   
            return new FileContentResult(doctor.DoctorPhoto, "image/jpeg");
        }
    }
}