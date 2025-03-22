using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Khóa ngoại tham chiếu đến Sinhvien
        public string SinhVienId { get; set; }

        [ForeignKey("SinhVienId")]
        public virtual Sinhvien SinhVien { get; set; }
    }
}
