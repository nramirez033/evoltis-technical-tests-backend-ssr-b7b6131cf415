﻿namespace technical_tests_backend_ssr.DTOs
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public DateTime FechaIngreso { get; set; }
    }
}