using technical_tests_backend_ssr.DTOs;

namespace technical_tests_backend_ssr.Services
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDTO>> ListarAsync();
        Task<EmpleadoDTO?> ObtenerByIdAsync(int id);
        Task<EmpleadoDTO> AgregarAsync(EmpleadoDTO dto);
        Task<EmpleadoDTO?> ActualizarAsync(int id, EmpleadoDTO dto);
        Task<bool> EliminarAsync(int id);
    }
}