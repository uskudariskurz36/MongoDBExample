using System.ComponentModel.DataAnnotations;

namespace BlogSampleWithEFCore.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
