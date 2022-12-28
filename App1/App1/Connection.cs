using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using static App1.MainPage;

namespace App1
{
    static class Connection
    {
        const string ConnectionString = "";
            static MongoClient client;

        public static IMongoDatabase db = null;
        public static IMongoCollection<Acceleration> _Acceleration = null;

        public static MongoClient getClient() {

            if (client == null) 
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                client = new MongoClient(settings); 
            }

            return client;

        }

    }
}
