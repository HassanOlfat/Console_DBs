using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MongoDB.Driver.Core.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace console
{
    public class BooksService
    {
        private IConnectionString _con;
        private Books _book;
        public BooksService(IConnectionString con)
        {
            _con = con;
            _book = new Books();
        }
        public async Task<Books> FindAsync()
        {
            if (_con.getConnectionType() == ConnectionType.mongo)
            {
                MongoConnection mongoCon = new MongoConnection();
                var collection = mongoCon.getCollection("Books");
                var firstDocument = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
                _book = BsonSerializer.Deserialize<Books>(firstDocument);
                return _book;
            }
            if (_con.getConnectionType() == ConnectionType.sqlServer)
            {
                string queryString = "SELECT Top 1 * from dbo.Books ORDER BY _Id ASC;";
                using (SqlConnection connection = new SqlConnection(_con.getConnectionString()))
                {
                    using (SqlCommand command = new(queryString, connection))
                    {

                        connection.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataSet ds = new DataSet();
                        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        da.Fill(ds);

                        DataRow dr = ds.Tables[0].Rows[0];
                        _book.title = dr.Field<string>("title");
                        _book.isbn = dr.Field<string>("isbn");
                        var a = dr.Field<string>("authors");
                        if (dr.Field<string>("authors") != null)
                        {
                            var authors = dr.Field<string>("authors").Split(',').ToList();
                            _book.authors = authors;
                        }




                    }

                }
                return _book;
            }

            throw new Exception("No Opration for your DbType '" + _con.getConnectionType() + "'");
        }
    }
}
