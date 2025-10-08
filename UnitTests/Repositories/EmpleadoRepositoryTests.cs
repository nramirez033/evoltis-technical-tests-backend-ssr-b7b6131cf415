using Microsoft.EntityFrameworkCore;
using Xunit;
using technical_tests_backend_ssr.Domain;
using technical_tests_backend_ssr.Models;
using technical_tests_backend_ssr.Repositories;

namespace technical_tests_backend_ssr.UnitTests.Repositories
{
    public class EmpleadoRepositoryTests
    {
        private TechnicalTestDbContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TechnicalTestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Empleados")
                .Options;
            return new TechnicalTestDbContext(options);
        }

        [Fact]
        public async Task AgregarEmpleado_Test()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repo = new EmpleadoRepository(context);
            var empleado = new Empleado { Nombre = "Nahuel", Apellido = "Ramirez", Email = "test@test.com", Puesto = "Dev" };

            // Act
            var result = await repo.AgregarAsync(empleado);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Nahuel", result.Nombre);
            Assert.Single(context.Empleados);
        }

        [Fact]
        public async Task EliminarEmpleado_Test()
        {
            var context = GetInMemoryContext();
            var repo = new EmpleadoRepository(context);
            var empleado = new Empleado { Nombre = "Borrar", Apellido = "Test", Email = "delete@test.com" };
            context.Empleados.Add(empleado);
            await context.SaveChangesAsync();

            var deleted = await repo.EliminarAsync(empleado.Id);

            Assert.True(deleted);
            Assert.Empty(context.Empleados);
        }
    }
}
