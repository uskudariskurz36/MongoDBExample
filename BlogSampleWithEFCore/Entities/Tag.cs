using System.ComponentModel.DataAnnotations;

namespace BlogSampleWithEFCore.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Value { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
