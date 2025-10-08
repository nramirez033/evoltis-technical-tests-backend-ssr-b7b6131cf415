using AutoMapper;
using technical_tests_backend_ssr.DTOs;
using technical_tests_backend_ssr.Models;

namespace technical_tests_backend_ssr.Profiles
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
        }
    }
}
