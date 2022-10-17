using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NotesApi.Models
{
    public class Notes
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage="Title too long")]
        public string Title {get; set; } = string.Empty;
        [Required]
        [DisplayName("Note")]
        public string Message { get; set; } = string.Empty;
        public bool Done { get; set; } = false;
        public DateTime Added { get; set; } = DateTime.Now;
        
    }
}