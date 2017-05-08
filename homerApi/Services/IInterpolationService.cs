using System;
using System.Collections.Generic;
using homer.Controllers;
using homer.models;
using homerApi.Model;

namespace homerApi.Services
{
    public interface IInterpolationService
    {
        IEnumerable<Interpolation> GetInterpolationForInterval(DateTime from, DateTime to, TimeSpan interval, IEnumerable<Measurment> records);
    }
}