using System;
using System.Collections.Generic;
using System.Linq;
using homer.Controllers;
using homer.models;
using homerApi.Model;

namespace homerApi.Services
{
//    public interface IInterpolator
//    {
//        
//    }

    public class InterpolationService : IInterpolationService
    {
        public IEnumerable<Interpolation> GetInterpolationForInterval(DateTime from, DateTime to, TimeSpan interval, IEnumerable<Measurment> records)
        {
            var list = new List<Interpolation>();
            records = records.OrderBy(_ => _.Date);
            var range = to - from;
            var intervalsInRange = range.Ticks / interval.Ticks;
            for (DateTime i = from; i <= to; i = i + interval)
            {
                var PrevMeasurment = records.LastOrDefault(_ => _.Date <= i)?? records.First();
                var NextMeasurment = records.FirstOrDefault(_ => _.Date >= i) ?? records.Last();
                if (PrevMeasurment.Date == NextMeasurment.Date)
                    list.Add(new Interpolation
                    {
                        Data = PrevMeasurment.Date,
                        Value = PrevMeasurment.Value
                    });
                else
                {

                    var yPoint = PrevMeasurment.Value + (i.Ticks - PrevMeasurment.Date.Ticks) *
                                 (NextMeasurment.Value - PrevMeasurment.Value) /
                                 (NextMeasurment.Date.Ticks - PrevMeasurment.Date.Ticks);
                    list.Add(new Interpolation {Data = i, Value = yPoint});
                }
//                var proporiton = (i - PrevMeasurment.Date).TotalSeconds / (NextMeasurment.Date - i).TotalSeconds;
//                var
            }
            return list;
        }
    }
}