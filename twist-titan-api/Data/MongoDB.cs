using System;
using API.FreeBathroom.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace API.FreeBathroom.Data.Database {
    public class MongoDBContext 
    { 
        public IMongoDatabase DB {get;}
        public MongoDBContext (IConfiguration configuration){
            try{
                
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var cliente = new MongoClient(settings);
                DB = cliente.GetDatabase(configuration["DatabaseName"]);

            }
            catch(Exception e) {
                throw new MongoException("Não foi possível instanciar a o MongoDB por causa: "+e.Message);
            }

        }
        void MapClasse(){
            
                if(!BsonClassMap.IsClassMapRegistered(typeof(FreeBathRoom)))
                {
                    BsonClassMap.RegisterClassMap<FreeBathRoom>(
                        (cm) =>{ 
                                cm.AutoMap();
                                cm.MapProperty(fbr => fbr._rate);
                                cm.MapProperty(fbr => fbr._dicas);
                                cm.MapProperty(fbr => fbr._local);
                                cm.MapProperty(fbr => fbr._id);
                        }
                        );
                }

        }
    }
}