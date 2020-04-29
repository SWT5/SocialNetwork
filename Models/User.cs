using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson; 
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserName { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }

        public List<User> BlockedList { get; set; }


        // siger i browser at den forventer circle men indsætter i consol som en string, skal det være en string der skal være i listen? laver de andre klasser først inden vi tester videre på dette
        public List<Circle> Circles { get; set; }




    }
}
