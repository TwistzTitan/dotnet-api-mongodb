using System;
using API.FreeBathroom.Data.Collections;
using API.FreeBathroom.Model;
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
            
                if(!BsonClassMap.IsClassMapRegistered(typeof(AbstractBathRoom)))
                {
                    BsonClassMap.RegisterClassMap<AbstractBathRoom>(
                        cm => cm.AutoMap());
                }

        }
    }
}