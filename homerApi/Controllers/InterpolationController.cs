using System;
using System.Collections.Generic;
using System.Linq;
using homer.models;
using homer.Repositories;
using homerApi.Model;
using homerApi.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{from:datetime}/{to:datetime}/{typeID}")]
        public List<Interpolation> Interepolation(DateTime from, DateTime to, int typeID)
        {
            var records = _Measurments.Get().Where(_ => _.MeasurmentType == typeID && _.Date >= from && _.Date <= to);
            return _interpolationService.GetInterpolationForInterval(@from, to, TimeSpan.FromDays(1), records).ToList();
        }
    }
}