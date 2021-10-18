using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ms.Models
{
    public class Ping
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Message { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
    }
}
