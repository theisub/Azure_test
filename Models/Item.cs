using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DSIP_.Models
{
    [BsonIgnoreExtraElements]
    public class Item
    { 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string ItemName { get; set; }

        public float Value { get; set; }

        public string ItemMaster { get; set; }
    }
}

//5d7672457fc6dd4730c53de5