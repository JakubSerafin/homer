using System;
using System.Linq;
using homer.models;
using homer.Repositories;

namespace homer.Controllers
{
    public interface IInterpolationService
    {
        Interpolation GetInterpolation(DateTime from, DateTime to, IQueryable<Measurment> records);
    }
}