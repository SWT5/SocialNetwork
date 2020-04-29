using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Configuration;

namespace SocialNetwork.Models
{
    public class SocialNetworkDatabaseSettings : ISocialNetworkDatabaseSettings
    {
        public string UserCollectionName { get; set; }

        public string PostCollection { get; set; }

        public string CircleCollection { get; set; }

        public string FeedCollection { get; set; }

        public string WallCollection { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

    }


    public interface ISocialNetworkDatabaseSettings
    {
        string UserCollectionName { get; set; }

        string PostCollection { get; set; }

        string CircleCollection { get; set; }

        string FeedCollection { get; set; }

        string WallCollection { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

    }
}