using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Notella.Models
{
    public class Notes
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
