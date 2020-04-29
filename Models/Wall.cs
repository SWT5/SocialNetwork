using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Wall
    {
        
        public string UserID { get; set; }
        public User UsersWall { get; set; }

        public string GuestID { get; set; }

        public User Guest { get; set; }

        //public List<Post> WallPosts { get; set; }

    }
}
