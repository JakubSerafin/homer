using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using homer.models;
using Microsoft.AspNetCore.Mvc;
using homer.Repositories;

namespace homer.Controllers
{
    [Route("api/[controller]")]
    public class MeasurementsController : Controller
    {
        private IRepository<Measurment> _measurmentRepo;

        MeasurementsController(IRepository<Measurment> measurmentRepo)
        {
            _measurmentRepo = measurmentRepo;
        }
        //private List<Measurment> measurments {get; set;} = new Measurment[] { new Measurment("Measurement1") { Id = 1 }, new Measurment("Measurement2") { Id = 2 } }.ToList();
        // GET api/Measurements
        [HttpGet]
        public IEnumerable<Measurment> Get()
        {
            return _measurmentRepo.Get();
        }

        // GET api/Measurements/5
        [HttpGet("{id}")]
        public Measurment Get(int id)
        {
            return _measurmentRepo.GetByID(id);
        }

        // POST api/Measurements
        [HttpPost]
        public void Post([FromBody]Measurment Measurement)
        {
        }

        // PUT api/Measurements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Measurment Measurement)
        {
            _measurmentRepo.Insert(Measurement);
        }

        // DELETE api/Measurements/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
