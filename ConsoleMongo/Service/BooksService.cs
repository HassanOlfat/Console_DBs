using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace console
{
   public class BooksService 
    {
       private IConnectionString _con;
        private Books _books;
        public BooksService(IConnectionString con)
        {
            _con = con;
        }
        public Books FindAsync()
        {
            if (_con.getConnectionType() == ConnectionType.mongo)
            {
                MongoConnection mongoCon = new MongoConnection();
                var collection=  mongoCon.getCollection("Books");
                var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
                _books = BsonSerializer.Deserialize<Books>(firstDocument);
                return _books;
            }


            throw new Exception ("No Opration for your DbType '"+ _con.getConnectionType() + "'"); 
        }
    }
}
