using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class CircleService
    {
        private readonly IMongoCollection<Circle> _circles;

        public CircleService(SocialNetworkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _circles = database.GetCollection<Circle>(settings.CircleCollection);
        }


        //Different get methods************************
        public List<Circle> Get() => _circles.Find(circle => true).ToList();

        public Circle Get(string circleName) =>
            _circles.Find<Circle>(circle => circle.CircleName == circleName).FirstOrDefault();



        //Different create methods************************
        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }


        //Different Update methods************************
        public void Update(string circleName, Circle circleIn) =>
            _circles.ReplaceOne(circle => circle.CircleName == circleName, circleIn);


        //Different Remove methods************************
        public void Remove(Circle circleIn) =>
            _circles.DeleteOne(circle => circle.CircleName == circleIn.CircleName);

        public void Remove(string circleName) =>
            _circles.DeleteOne(circle => circle.CircleName == circleName);



    }
}
