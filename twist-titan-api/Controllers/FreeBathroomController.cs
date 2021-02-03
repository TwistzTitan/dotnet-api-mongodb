using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using API.FreeBathroom.Data.Collections;
using API.FreeBathroom.Data.Database;
using API.FreeBathroom.Model;

namespace API.FreeBathroom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreeBathRoomController : ControllerBase
    {
        
        private IMongoCollection<FreeBathRoom> _collection;
        private IMongoDatabase _mongo;

        private IBathRoomInformation _avaliadorBath;
        

        public FreeBathRoomController(MongoDBContext instance, IBathRoomInformation avaliadorBath){

                _mongo = instance.DB; 
                _avaliadorBath = avaliadorBath;
                _collection = _mongo.GetCollection<FreeBathRoom>(typeof(FreeBathRoom).Name.ToLower());

        }
        
        [HttpGet("getAll")]
        public IActionResult GetAllFreeBathRoom(){
           var filter = Builders<FreeBathRoom>.Filter.Gt("avaliacao",2);
           var freeBathRooms = _collection.Find(filter).FirstOrDefault();
           return StatusCode(200,freeBathRooms);

        }

        [HttpPost("postOne")]
        [Consumes("application/json")]
        public IActionResult PostOne ([FromBody] FreeBathRoomDTO dto){
            
            FreeBathRoom freeBathRoomOne = new FreeBathRoom(dto.rate, dto.dicas,dto.latitude,dto.longitude);
            _avaliadorBath.Avaliar(freeBathRoomOne,freeBathRoomOne.avaliacao);      
            _collection.InsertOne(freeBathRoomOne);
            return Created("Criado novo FreeBathRoom",freeBathRoomOne);
            
        }
    }
}