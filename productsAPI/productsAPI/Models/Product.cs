using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    /* 

    [BsonElement("Type")]
    public string ProductType { get; set; } */


    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("ProductName")]
    public string ProductName { get; set; }

    [BsonElement("ProductUrl")]
    public string ProductUrl { get; set; }
}