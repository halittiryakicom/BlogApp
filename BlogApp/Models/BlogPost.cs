using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık gereklidir.")]
        [StringLength(100, ErrorMessage = "100 Karakterden fazla olamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik gereklidir.")]
        public string Content { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
