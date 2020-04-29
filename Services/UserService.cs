using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class UserService
    {

        private readonly IMongoCollection<User> _users;

        public UserService(ISocialNetworkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string username) =>
            _users.Find<User>(user => user.UserName == username).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string username, User userIn) =>
            _users.ReplaceOne(user => user.UserName == username, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.UserName == userIn.UserName);

        public void Remove(string username) =>
            _users.DeleteOne(user => user.UserName == username); 

    }
}
