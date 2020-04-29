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

        public List<Circle> Circles { get; set; }




    }
}
