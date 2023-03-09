using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIServiceLifetime.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITransient _transient;
        private readonly IScoped _scoped;
        private readonly ISingleton _singleton;


        public WeatherForecastController(ILogger<WeatherForecastController> logger,ITransient transient, IScoped scoped, ISingleton singleton)
        {
            _logger = logger;
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        [HttpGet(Name = "Endpoint1")]
        public List<string> Get()
        {
            var output = new List<string>();
            Console.WriteLine("Request 1");
            output.Add(_transient.Info());
            output.Add(_scoped.Info());
            output.Add(_singleton.Info());
            return output;
        }
        //Scoped will return different guid for req2 then req1 as transient thats incorrect understanding
        //because request2 itself is a new client request to api.
        //scoped will use same instance within a client request which means request 2 is initiated to endpoint 2 of controller
        //and controller relies service1 and controller makes calls to helper classes which will again relies service1
        //or some middlware which relied same service1.
        //So Controller class,helperclass , middleware class all dependents on same service1 from DI container.
        //So DI container provides same instance for all these 3 places in terms of scoped
        //and different instances[ins1 for controller, ins2 for helper, ins3 for middleware] in terms of transient.
        [HttpPost(Name = "Endpoint2")]
        public List<string> Post()
        {
            var output = new List<string>();
            Console.WriteLine("Request 2");
            output.Add(_transient.Info());
            output.Add(_scoped.Info());
            output.Add(_singleton.Info());
            return output;
        }
    }
}
