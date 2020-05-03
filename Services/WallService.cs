using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class WallService
    {
        private readonly IMongoCollection<Wall> _walls;

        public WallService(ISocialNetworkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _walls = database.GetCollection<Wall>(settings.WallCollection);
        }

        public List<Wall> Get() =>
            _walls.Find(wall => true).ToList();

        public Wall Get(string userID) =>
            _walls.Find<Wall>(wall => wall.UserID == userID).FirstOrDefault();

        public Wall Create(Wall wall)
        {
            _walls.InsertOne(wall);
            return wall;
        }

        public void Update(string userID, Wall wallIn) =>
            _walls.ReplaceOne(wall => wall.UserID == userID, wallIn);

        public void Remove(Wall wallIn) =>
            _walls.DeleteOne(wall => wall.UserID == wallIn.UserID);

        public void Remove(string userID) =>
            _walls.DeleteOne(wall => wall.UserID == userID); 


    }
}
