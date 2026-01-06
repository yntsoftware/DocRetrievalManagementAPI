using System.ComponentModel.DataAnnotations;

namespace DocRetrievalManagementAPI.Models
{
    public class Documents
    {
        [Key]
        public Int64 Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; } 
        [Required]
        public DateTime UploadedAt { get; set; }
        [Required]
        public string UploadedBy { get; set; }
        public bool IsActive { get; set; }

    }

    public class DocModel {

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(150, ErrorMessage = "Title must not exceed 150 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }
    }
}
