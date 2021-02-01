using System;
using API.FreeBathroom.Model;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
namespace API.FreeBathroom.Data.Collections {
       
       [BsonIgnoreExtraElements]
       public class FreeBathRoom {

              [BsonId]
              public int _id { get; private set;}

              [BsonElement("rate")]
              public int _rate { get ; set;}

              [BsonElement("dicas")]
              public String _dicas {get ; set;}
              
              [BsonElement("localization")]
              public GeoJson2DGeographicCoordinates _local {get ; private set;}
              
              public FreeBathRoom(int rate, String dicas,double latitude, double longitude) {

                     _rate = rate;
                     _dicas = dicas;
                     _local = new GeoJson2DGeographicCoordinates(latitude,longitude);

              }              
       
       }


} 
