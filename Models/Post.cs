using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PostID { get; set; }

        public string Author { get; set; }
        public User PostsAuthor { get; set; }

        public DateTime CreationTime { get; set; }

        public string PostInCircle { get; set; }
        public Circle Circle { get; set; }

        public List<Comments> CommentsList { get; set; }

        public List<string> Content { get; set; }


    }


    public class Comments
    {
        public string Author { get; set; }
        public User CommentsAuthor { get; set; }

        public DateTime CommentCreationTime { get; set; }

        public string Text { get; set; }
    }
}
