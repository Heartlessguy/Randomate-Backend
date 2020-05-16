using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RandomAteDataManager.Models
{
    public class DishModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public RecipeModel Recipe { get; set; }

        public FeedbackModel[] Feedbacks { get; set; }

    }
}