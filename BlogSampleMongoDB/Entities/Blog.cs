using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogSampleMongoDB.Entities
{
    public class Blog
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
