using MongoDB.Driver;
using ms.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ms.Services
{
    public class PingService
    {
        private readonly IMongoCollection<Ping> _pings;

        public PingService(IPingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pings = database.GetCollection<Ping>(settings.CollectionName);
        }

        public List<Ping> Get()
        {
            Logging.LoggingHelper.WriteControllerInfoLog("Get");
            return _pings.Find(ping => true).ToList();
        }

        public Ping Get(string id)
        {
            Logging.LoggingHelper.WriteControllerInfoLog("Get");
            return _pings.Find<Ping>(ping => ping.Id == id).FirstOrDefault();
        }


        public Ping Create(Ping ping)
        {
            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
            Logging.LoggingHelper.WriteControllerInfoLog("Create");
            _pings.InsertOne(ping);
            return ping;
        }
    }

}
