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
        

        public FreeBathRoomController(MongoDBContext instance){

                _mongo = instance.DB; 
                _collection = _mongo.GetCollection<FreeBathRoom>(typeof(FreeBathRoom).Name.ToLower());

        }
        
        [HttpGet("getAll")]
        public IActionResult GetAllFreeBathRoom(){

           var freeBathRooms = _collection.Find(FilterDefinition<FreeBathRoom>.Empty);
           return StatusCode(200,freeBathRooms);

        }

        [HttpPost("postOne")]
        [Consumes("application/json")]
        public IActionResult PostOne ([FromBody] FreeBathRoomDTO dto){
            
            var freeBathRoomOne = new FreeBathRoom(dto.rate, dto.dicas,dto.latitude,dto.longitude);        
            _collection.InsertOne(freeBathRoomOne);
            return Created("Criado novo FreeBathRoom",freeBathRoomOne);
            
        }
    }
}