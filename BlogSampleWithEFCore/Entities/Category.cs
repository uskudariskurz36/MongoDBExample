using System.ComponentModel.DataAnnotations;

namespace BlogSampleWithEFCore.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}
