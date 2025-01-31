using System;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Subtitle { get; set; }

        [Required]
        public string Content { get; set; }

        [MaxLength(500)]
        public string ImagePath { get; set; }

        [Required]
        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}
