using Microsoft.AspNetCore.Mvc;
using ms.Models;
using ms.Services;
using System;
using System.Collections.Generic;
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

        [HttpGet]
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
            _pingService.Create(ping);
            return CreatedAtRoute("GetPing", new { id = ping.Id.ToString() }, ping);
        }

    }
}
