using System.ComponentModel.DataAnnotations;

namespace BlogSampleWithEFCore.Entities
{
    public class LikeUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public DateTime LikeDate { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
