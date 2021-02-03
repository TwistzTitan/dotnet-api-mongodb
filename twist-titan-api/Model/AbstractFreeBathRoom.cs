using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver.GeoJsonObjectModel;

namespace API.FreeBathroom.Model
{
     public abstract class AbstractBathRoom
    {
       [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
              private string _id { get; set;}

              [BsonElement("avaliacao")]
              public int avaliacao { get ; set;}

              [BsonElement("avaliacaoNegativa")]
              public int avaliacaoNegativa {get; set;}
              
              [BsonElement("avaliacaoPositiva")]
              public int avaliacaoPositiva {get; set;}
              
              [BsonElement("dicas")]
              public String dicas {get ; set;}
              
              [BsonElement("localizacao")]
              public GeoJson2DGeographicCoordinates local {get ; set;}
              
    }
}