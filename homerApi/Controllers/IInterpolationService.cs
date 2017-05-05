using System;
using System.Collections.Generic;
using System.Linq;
using homer.models;
using homer.Repositories;

namespace homer.Controllers
{
    public interface IInterpolationService
    {
        IEnumerable<Interpolation> GetInterpolationForInterval(DateTime from, DateTime to, TimeSpan interval, IEnumerable<Measurment> records);
    }
}