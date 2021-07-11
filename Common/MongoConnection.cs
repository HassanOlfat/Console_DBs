using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MongoConnection : IConnectionString
    {
        public string getAddress()
        {
            return "mongodb://localhost:27017";
        }
        public string getDatabasename()
        {
            return "Test";
        }
        public ConnectionType getConnectionType()
        {
            return ConnectionType.mongo;
        }
        public string getUserName()
        {
            return null;
        }
        public string getPassword()
        {
            return null;
        }

        public string getConnection()
        {

            if (getUserName() == null) return getAddress();
            else
            {
                return "mongodb+srv://" + getUserName() + ":" + getPassword() + "@" + getAddress() + "/" + getDatabasename() + "?retryWrites=true&w=majority";
            }
        }

        public bool getPing()
        {
            MongoClient client = new MongoClient(getConnection());
            var database = client.GetDatabase(getDatabasename());

            bool isMongoLive = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);

            return isMongoLive;
        }


        public List<BsonDocument> getDatabasNames()
        {
            MongoClient client = new MongoClient(getConnection());
            var database = client.GetDatabase(getDatabasename());

            var dbList = client.ListDatabases().ToList();

            return dbList;
        }
        public IMongoDatabase getDatabase()
        {
            MongoClient client = new MongoClient(getConnection());
            var database = client.GetDatabase(getDatabasename());


            return database;
        }

        public IMongoCollection<BsonDocument> getCollection(string collectionName)
        {
           

            var collection = getDatabase().GetCollection<BsonDocument>(collectionName);

            return collection;
        }
        
    }
}
