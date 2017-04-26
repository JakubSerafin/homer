using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homer.models;
using Microsoft.AspNetCore.Mvc;

namespace homer.Controllers
{
    [Route("api/[controller]")]
    public class MeasurementsController : Controller
    {
        private List<Measurment> measurments {get; set;} = new Measurment[] {new Measurment("Measurement1"), new Measurment("Measurement2") }.ToList();
        // GET api/Measurements
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Measurement1", "Measurement2" };
        }

        // GET api/Measurements/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Measurement";
        }

        // POST api/Measurements
        [HttpPost]
        public void Post([FromBody]string Measurement)
        {
        }

        // PUT api/Measurements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string Measurement)
        {
        }

        // DELETE api/Measurements/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
