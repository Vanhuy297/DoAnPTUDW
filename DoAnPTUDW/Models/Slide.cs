using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnPTUDW.Models
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        public long SlideID { get; set;}
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Images { get; set; }
        public bool? IsActive { get; set; }
        public int SlideOrder { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }
    }
}
