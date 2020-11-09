using MongoDB.Bson.Serialization.Attributes;

namespace SpecificationsLearn.Models
{
    public class ModelBase
    {
        [BsonId]
        public virtual int Id { get; set; }
    }
}
