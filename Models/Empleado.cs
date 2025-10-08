using System.ComponentModel.DataAnnotations;

namespace technical_tests_backend_ssr.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Puesto { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }
}
