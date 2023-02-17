using System.ComponentModel.DataAnnotations;
using University_API_Backend.Enums;

namespace University_API_Backend.Models
{
    public class Usuario : BaseEntity
    {
        [Required, StringLength(50)]
        public string nombre { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string apellidos { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required]
        public string contrasenia { get; set; } = string.Empty;
        [Required]
        public RolUsr rol { get; set; }
    }
}
