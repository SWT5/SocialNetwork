using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _Post;

        public PostService(ISocialNetworkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Post = database.GetCollection<Post>(settings.PostCollection);
        }

        public List<Post> Get() =>
            _Post.Find(post => true).ToList();

        public Post Get(string id) =>
            _Post.Find<Post>(post => post.PostID == id).FirstOrDefault();

        public Post Create(Post post)
        {
            _Post.InsertOne(post);
            return post;
        }

        public void Update(string id, Post postIn) =>
            _Post.ReplaceOne(post => post.PostID == id, postIn);

        public void Remove(Post postIn) =>
            _Post.DeleteOne(post => post.PostID == postIn.PostID);

        public void Remove(string id) =>
            _Post.DeleteOne(post => post.PostID == id);

    }
}
