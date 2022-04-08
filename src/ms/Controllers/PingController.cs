using Microsoft.AspNetCore.Mvc;
using ms.Models;
using ms.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly PingService _pingService;

        public PingController(PingService pingService)
        {
            _pingService = pingService;
        }


        [HttpGet(Name = "GetPings")]
        public ActionResult<List<Ping>> Get() => _pingService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPing")]
        public ActionResult<Ping> Get(string id)
        {
            var ping = _pingService.Get(id);

            if (ping == null)
            {
                return NotFound();
            }

            return ping;
        }

        [HttpPost]
        public ActionResult<Ping> Create(Ping ping)
        {
            DateTime currentDateTime = DateTime.UtcNow;
            ping.Timestamp = currentDateTime;
            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
            switch (ping.Message)
            {
                case "error":
                    Log.Error("{message} message triggered.", ping.Message);
                    break;

                case "warning":
                    Log.Warning("{message} message triggered.", ping.Message);
                    break;

                case "information":
                    Log.Information("{message} message triggered.", ping.Message);
                    break;

                case "debug":
                    Log.Debug("{message} message triggered.", ping.Message);
                    break;

                case "verbose":
                    Log.Verbose("{message} message triggered.", ping.Message);
                    break;

                case "fatal":
                    Log.Fatal("{message} message triggered.", ping.Message);
                    break;

                default:
                    _pingService.Create(ping);
                    return CreatedAtRoute("GetPing", new { id = ping.Id.ToString() }, ping);
            }

            return CreatedAtRoute("GetPings",ping);
        }

    }
}
