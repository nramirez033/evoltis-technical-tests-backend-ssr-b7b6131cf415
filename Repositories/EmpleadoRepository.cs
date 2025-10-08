using Microsoft.EntityFrameworkCore;
using technical_tests_backend_ssr.Models;
using technical_tests_backend_ssr.Domain;

namespace technical_tests_backend_ssr.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly TechnicalTestDbContext _context;

        public EmpleadoRepository(TechnicalTestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> ListarAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> ObtenerByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task<Empleado> AgregarAsync(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<Empleado> ActualizarAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
