using DocAppointment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Моля, въведете вашите имена!")]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Моля, изберете пол!")]
        [Display(Name = "Пол")]
        public int? GenderId { get; set; }

        [Required(ErrorMessage = "Моля, въведете дата на раждане!")]
        [Display(Name = "Дата на раждане")]
        [DataType(DataType.Date, ErrorMessage = "Грешен формат за дата!")]
        [Min18Age]
        public DateTime? Birthdate { get; set; }

        public bool IsSecuredByNHIF { get; set; }

        public byte[] UserPhoto { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}