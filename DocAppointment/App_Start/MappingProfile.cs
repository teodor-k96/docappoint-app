using AutoMapper;
using DocAppointment.Dtos;
using DocAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocAppointment.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();

            CreateMap<City, CityDto>();
            CreateMap<Specialty, SpecialtyDto>();

            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment>();
        }
    }
}