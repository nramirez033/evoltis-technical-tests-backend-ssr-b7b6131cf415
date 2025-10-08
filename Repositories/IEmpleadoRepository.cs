using technical_tests_backend_ssr.Models;

namespace technical_tests_backend_ssr.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> ListarAsync();
        Task<Empleado?> ObtenerByIdAsync(int id);
        Task<Empleado> AgregarAsync(Empleado empleado);
        Task<Empleado> ActualizarAsync(Empleado empleado);
        Task<bool> EliminarAsync(int id);
    }
}
