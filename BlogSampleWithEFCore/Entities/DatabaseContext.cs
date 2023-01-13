using MFramework.Services.FakeData;
using Microsoft.EntityFrameworkCore;

namespace BlogSampleWithEFCore.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            if (Categories.Any() == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Category category = new Category()
                    {
                        Name = NameData.GetCompanyName(),
                    };

                    Categories.Add(category);

                }
                SaveChanges();
            }

            if (Authors.Any() == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Author authors = new Author()
                    {
                        Name = NameData.GetFirstName(),
                        Surname = NameData.GetSurname(),
                    };

                    Authors.Add(authors);

                }
                SaveChanges();
            }
            if (Posts.Any() == false)
            {
                List<Category> categories = Categories.ToList();
                List<Author> authors = Authors.ToList();

                for (int i = 0; i < 20; i++)
                {
                    Post post = new Post()
                    {
                        Title = TextData.GetAlphabetical(15),
                        Description = TextData.GetSentences(2),
                        IsDraft = BooleanData.GetBoolean(),
                        CreatedDate = DateTimeData.GetDatetime(),
                        AuthorId = CollectionData.GetElement(authors).Id,
                        CategoryId = CollectionData.GetElement(categories).Id
                    };

                    Posts.Add(post);

                }
                SaveChanges();
            }
            if (Tags.Any() == false)
            {
                List<Post> posts = Posts.ToList();
                for (int i = 0; i < 100; i++)
                {
                    Tag tags = new Tag()
                    {
                        Value = NameData.GetTitleName(),
                        PostId = CollectionData.GetElement(posts).Id
                    };

                    Tags.Add(tags);

                }
                SaveChanges();
            }
            if (LikeUsers.Any() == false)
            {
                List<Post> posts = Posts.ToList();
                for (int i = 0; i < 500; i++)
                {
                    LikeUser likeUser = new LikeUser()
                    {
                        Name = NameData.GetFirstName(),
                        Surname = NameData.GetSurname(),
                        PostId = CollectionData.GetElement(posts).Id,
                        LikeDate = DateTimeData.GetDatetime(),
                    };

                    LikeUsers.Add(likeUser);

                }
                SaveChanges();
            }
            if (Comments.Any() == false)
            {
                List<Post> posts = Posts.ToList();
                for (int i = 0; i < 300; i++)
                {
                    Comment comment = new Comment()
                    {
                        Text = TextData.GetAlphabetical(20),
                        CreatedDate = DateTimeData.GetDatetime(),
                        PostId = CollectionData.GetElement(posts).Id,

                    };

                    Comments.Add(comment);

                }
                SaveChanges();
            }
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<LikeUser> LikeUsers { get; set; }
    }
}
