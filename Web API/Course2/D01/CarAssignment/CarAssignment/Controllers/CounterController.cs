using CarAssignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace CarAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {

        private readonly CounterServices _counter;
        public CounterController(CounterServices counter) {
            _counter = counter;
        }

        [HttpGet]
        public ActionResult<int> GetCounter()
        {
            return Ok(_counter.Counter);
        }
    }
}
