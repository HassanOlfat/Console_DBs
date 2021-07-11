
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

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {

            IConnectionString mongo = new MongoConnection();

            Console.WriteLine("*********** Connection Test ********* \n");

            Console.WriteLine("pingMongo : " + mongo.getPing());

            BooksService bs = new BooksService(mongo);


            Console.WriteLine("\n \n");

            var firstBook = bs.FindAsync();


            Console.WriteLine("*********** First Book ********* \n");
            Console.WriteLine("Title : {0}", firstBook.title);
            Console.WriteLine("ISBN : {0}", firstBook.isbn);
            
            Console.ReadKey();
        }

    }
}
