using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Servies.Catalog.Model
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
