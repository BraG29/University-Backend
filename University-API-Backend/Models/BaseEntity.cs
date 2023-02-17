using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_API_Backend.Models
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [ForeignKey("created_by")]
        public Usuario? CreatedBy { get; set; }
        //public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("updated_by")]
        public Usuario? UpdatedBy { get; set; }
        //public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [ForeignKey("deleted_by")]
        public Usuario? DeletedBy { get; set; }
        //public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool isDeleted { get; set; } = false;

    }
}
