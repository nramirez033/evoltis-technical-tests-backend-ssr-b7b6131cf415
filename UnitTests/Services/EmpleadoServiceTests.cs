using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;
using technical_tests_backend_ssr.Profiles;
using technical_tests_backend_ssr.Services;
using technical_tests_backend_ssr.Repositories;
using technical_tests_backend_ssr.Domain;
using technical_tests_backend_ssr.Models;
using technical_tests_backend_ssr.DTOs;

namespace technical_tests_backend_ssr.UnitTests.Services
{
    public class EmpleadoServiceTests
    {
        private readonly IMapper _mapper;

        public EmpleadoServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<EmpleadoProfile>());
            _mapper = config.CreateMapper();
        }

        private TechnicalTestDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<TechnicalTestDbContext>()
                .UseInMemoryDatabase("TestDB_Service")
                .Options;
            return new TechnicalTestDbContext(options);
        }

        [Fact]
        public async Task CrearEmpleado_Test()
        {
            var context = GetContext();
            var repo = new EmpleadoRepository(context);
            var service = new EmpleadoService(repo, _mapper);
            var dto = new EmpleadoDTO { Nombre = "Juan", Apellido = "Pérez", Email = "jp@test.com", Puesto = "QA" };

            var result = await service.AgregarAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("Juan", result.Nombre);
            Assert.Single(await repo.ListarAsync());
        }

        [Fact]
        public async Task ObtenerEmpleados_Test()
        {
            var context = GetContext();
            context.Empleados.Add(new Empleado { Nombre = "A", Apellido = "B", Email = "a@b.com" });
            context.Empleados.Add(new Empleado { Nombre = "C", Apellido = "D", Email = "c@d.com" });
            await context.SaveChangesAsync();

            var repo = new EmpleadoRepository(context);
            var service = new EmpleadoService(repo, _mapper);

            var result = await service.ListarAsync();

            Assert.Equal(2, result.Count());
        }
    }
}
