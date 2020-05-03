using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class FeedService
    {
        private readonly IMongoCollection<Feed> _feed;

        public FeedService(ISocialNetworkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _feed = database.GetCollection<Feed>(settings.FeedCollection);
        }

        public List<Feed> Get() =>
            _feed.Find(feed => true).ToList();

        public Feed Get(string FeedId) =>
            _feed.Find<Feed>(Feed => Feed.FeedID == FeedId).FirstOrDefault();

        public Feed Create(Feed feed)
        {
            _feed.InsertOne(feed);
            return feed;
        }
        public void Update(string id, Feed FeedId) =>
            _feed.ReplaceOne(feed => feed.FeedID == id, FeedId);

        public void Remove(Feed FeedIn) =>
            _feed.DeleteOne(Feed => Feed.FeedID == FeedIn.FeedID);

        public void Remove(string id) =>
            _feed.DeleteOne(Feed => Feed.FeedID == id);

    }
}
