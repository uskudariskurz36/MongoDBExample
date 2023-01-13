using System.ComponentModel.DataAnnotations;

namespace BlogSampleWithEFCore.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(5000)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDraft { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; }
        public List<LikeUser> LikeUsers { get; set; }
    }
}
