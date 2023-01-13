namespace BlogSampleMongoDB.Models
{
    public class BlogCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

    public class BlogEditViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
