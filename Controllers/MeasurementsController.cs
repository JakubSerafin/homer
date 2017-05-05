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
    public class InterpolationController: Controller
    {
        private IRepository<Measurment> _Measurments;
        private IInterpolationService _interpolationService;

        public InterpolationController(IRepository<Measurment> typeRepo, IInterpolationService interpolationService)
        {
            _Measurments = typeRepo;
            _interpolationService = interpolationService;
        }

        [HttpGet("{from}/{to}/{typeID}")]
        public Interpolation Interepolation(DateTime from, DateTime to, int typeID)
        {
            var records = _Measurments.Get().Where(_ => _.MeasurmentType == typeID && _.Date >= from && _.Date <= to);
            return _interpolationService.GetInterpolation(from, to, records);
        }
    }


    [Route("api/[controller]")]
    public class MeasurementsController : Controller
    {
        private IRepository<Measurment> _measurmentRepo;
        private IRepository<IMeasurmentType>  _measurmentTypeRepo;

        public MeasurementsController(IRepository<Measurment> measurmentRepo, IRepository<IMeasurmentType> measurmentTypeRepo)
        {
            _measurmentRepo = measurmentRepo;
            _measurmentTypeRepo = measurmentTypeRepo;
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

        [HttpGet("{id}/Type")]
        public IMeasurmentType GetType(int id)
        {
            var Measurment = _measurmentRepo.GetByID(id);
            if(Measurment!=null)
            {
                return _measurmentTypeRepo.GetByID(Measurment.MeasurmentType);
            }
            return null;

        }

        // POST api/Measurements
        [HttpPost]
        public void Post([FromBody]Measurment Measurement)
        {
            _measurmentRepo.Update(Measurement);
        }

        // PUT api/Measurements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Measurment Measurement)
        {
            Measurement.Id = id;
            _measurmentRepo.Insert(Measurement);
        }

        // DELETE api/Measurements/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
