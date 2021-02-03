using System;
using API.FreeBathroom.Model;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver.GeoJsonObjectModel;
namespace API.FreeBathroom.Data.Collections {
       
       [BsonIgnoreExtraElements]
       public class FreeBathRoom : AbstractBathRoom{
              
              public FreeBathRoom(int rate, String Dicas,double latitude, double longitude) {

                     dicas = Dicas;
                     local = new GeoJson2DGeographicCoordinates(latitude,longitude);

              }

              
       }


} 
