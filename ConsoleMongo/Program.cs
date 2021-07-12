
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Metadata;
using Common;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(" Please enter your Database Type name (Ex: sql , mongo) :  \n");
            Console.WriteLine(" Default Database : mongo  \n");

            string command = Console.ReadLine();

            
            IConnectionString db=null;

            if (command.ToLower()=="sql")
            {
                 db = new SqlServerConnection();
                Console.WriteLine("*********** Swich to SQL SERVER ********* \n");
            }
            else 
            {
                db = new MongoConnection();
                Console.WriteLine("*********** Swich to MongoDB ********* \n");
                Console.WriteLine("*********** Connection Test ********* \n");
                Console.WriteLine("pingMongo : " + db.getPing());

            }
            Console.WriteLine("\n \n");

            BooksService bs = new BooksService(db);
            var firstBook = await bs.FindAsync();


            Console.WriteLine("*********** First Book ********* \n");
            Console.WriteLine("Title : {0}", firstBook.title);
            Console.WriteLine("ISBN : {0}", firstBook.isbn);
            Console.WriteLine("Authors : ");

            foreach (var item in firstBook.authors)
            {
                Console.WriteLine("\t {0}",item);
            }
            Console.ReadKey();
        }

    }
}
