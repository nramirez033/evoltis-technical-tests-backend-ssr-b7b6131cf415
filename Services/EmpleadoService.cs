using AutoMapper;
using technical_tests_backend_ssr.DTOs;
using technical_tests_backend_ssr.Models;
using technical_tests_backend_ssr.Repositories;

namespace technical_tests_backend_ssr.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repo;
        private readonly IMapper _mapper;

        public EmpleadoService(IEmpleadoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpleadoDTO>> ListarAsync()
        {
            var list = await _repo.ListarAsync();
            return _mapper.Map<IEnumerable<EmpleadoDTO>>(list);
        }

        public async Task<EmpleadoDTO?> ObtenerByIdAsync(int id)
        {
            var empleado = await _repo.ObtenerByIdAsync(id);
            return empleado == null ? null : _mapper.Map<EmpleadoDTO>(empleado);
        }

        public async Task<EmpleadoDTO> AgregarAsync(EmpleadoDTO dto)
        {
            var entity = _mapper.Map<Empleado>(dto);
            var added = await _repo.AgregarAsync(entity);
            return _mapper.Map<EmpleadoDTO>(added);
        }

        public async Task<EmpleadoDTO?> ActualizarAsync(int id, EmpleadoDTO dto)
        {
            var existing = await _repo.ObtenerByIdAsync(id);
            if (existing == null) return null;
            _mapper.Map(dto, existing);
            var updated = await _repo.ActualizarAsync(existing);
            return _mapper.Map<EmpleadoDTO>(updated);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repo.EliminarAsync(id);
        }
    }
}