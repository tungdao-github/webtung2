using System;
using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models
{
    
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }  // Đường dẫn ảnh

        public string Description { get; set; }  // Mô tả ảnh

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Thời gian tạo
    }
}