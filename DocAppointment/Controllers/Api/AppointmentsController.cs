using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using DocAppointment.Models;
using DocAppointment.Dtos;
using Microsoft.AspNet.Identity;

namespace DocAppointment.Controllers.Api
{
    public class AppointmentsController : ApiController
    {
        private ApplicationDbContext _context;

        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/appointments
        [HttpGet]
        public IHttpActionResult GetAppointments(int doctorId = 0, bool firstAvailable = false, string userId = null)
        {
            IEnumerable<AppointmentDto> appointmentDtos = null;

            // get all the appointments
            List<Appointment> appointmentsQuery = new List<Appointment>();

            if(doctorId != 0)
            {
                appointmentsQuery = _context.Appointments.Where(c => c.Doctor.Id == doctorId)
                               .Where(c => c.DateOfAppointment > DateTime.Now)
                               .OrderBy(m => m.DateOfAppointment).ToList();
            }

            if (firstAvailable == true)
            {
                var minTimeForAppointment = _context.Doctors.Single(c => c.Id == doctorId).WorktimeStart.Value.TimeOfDay;
                var maxTimeForAppointment = _context.Doctors.Single(c => c.Id == doctorId).WorktimeEnd.Value.TimeOfDay.Add(new TimeSpan(0, -30, 0));

                var datetimeNow = DateTime.Now;

                int differenceInMinutes = 0;

                DateTime firstAvailableDate = new DateTime();

                if (datetimeNow.Minute >= 30)
                    differenceInMinutes = 60 - datetimeNow.Minute;
                else
                    differenceInMinutes = 30 - datetimeNow.Minute;

                DateTime checkedDate = datetimeNow.AddMinutes(differenceInMinutes);

                int i = 0;
                string currentDateTimeFromList;

                do
                {
                    bool flag = false;

                    if (checkedDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        checkedDate = checkedDate.AddDays(2);
                        flag = true;
                    }
                    else if (checkedDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        checkedDate = checkedDate.AddDays(1);
                        flag = true;
                    }
                    else if (checkedDate.TimeOfDay > maxTimeForAppointment && checkedDate.DayOfWeek == DayOfWeek.Friday)
                    {
                        checkedDate = checkedDate.AddDays(3);
                        flag = true;
                    }
                    else if (checkedDate.TimeOfDay > maxTimeForAppointment && minTimeForAppointment < maxTimeForAppointment)
                    {
                        checkedDate = checkedDate.AddDays(1);
                        flag = true;
                    }
                    else if (checkedDate.TimeOfDay < minTimeForAppointment)
                    {
                        flag = true;
                    }

                    if (flag == true)
                    {
                        // changing the time to be equal to the worktimeStart
                        TimeSpan ts = new TimeSpan(minTimeForAppointment.Hours, minTimeForAppointment.Minutes, 0);
                        checkedDate = checkedDate.Date + ts;
                    }

                    if (appointmentsQuery.Count != 0 && i < appointmentsQuery.Count)
                    {
                        currentDateTimeFromList = appointmentsQuery[i].DateOfAppointment.ToString("g");

                        if (currentDateTimeFromList == checkedDate.ToString("g"))
                        {
                            checkedDate = checkedDate.AddMinutes(30);
                            firstAvailableDate = checkedDate;
                            i++;
                            continue;
                        }
                        else
                        {
                            firstAvailableDate = checkedDate;
                            break;
                        }
                    }
                    else
                    {
                        firstAvailableDate = checkedDate;
                        continue;
                    }
                } while (i < appointmentsQuery.Count
                        || (checkedDate.TimeOfDay > maxTimeForAppointment && minTimeForAppointment < maxTimeForAppointment)
                        || checkedDate.TimeOfDay < minTimeForAppointment
                        || checkedDate.DayOfWeek == DayOfWeek.Saturday);

                return Ok(firstAvailableDate);
            }

            // get the appointments by current userId
            if (userId != null)
            {
                appointmentsQuery = _context.Appointments.Include(c => c.Client).Include(c => c.Doctor).Include(c => c.Doctor.Specialty).OrderBy(m => m.DateOfAppointment)
                                                .Where(m => m.Client.Id == userId).ToList();

                appointmentDtos = appointmentsQuery.ToList().Select(Mapper.Map<Appointment, AppointmentDto>);

                return Ok(appointmentDtos);
            }

            appointmentDtos = appointmentsQuery.ToList().Select(Mapper.Map<Appointment, AppointmentDto>);

            return Ok(appointmentDtos);
        }

        [HttpDelete]
        public void DeleteAppointment(int id, string userId)
        {
            var appointmentInDb = _context.Appointments.Include(c => c.Client).Include(c => c.Doctor).SingleOrDefault(c => c.AppointmentId == id);

            var appointmentClientId = appointmentInDb.Client.Id;

            if (appointmentClientId != userId || appointmentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Appointments.Remove(appointmentInDb);
            _context.SaveChanges();
        }
    }
}
