using System;
using System.Collections.Generic;
using System.Linq;
using homer.Controllers;
using homer.models;
using Xunit;

namespace homerApi.Tests
{
    public class InterpolationServiceTests
    {
        [Fact]
        public void GetInterpolation_OneDayOneRecord_ReturnMeasurmentValue()
        {
            var service = new InterpolationService();
            var data = new List<Measurment>() { new Measurment { Date = DateTime.Today, Value = 10 } };

            var interpolations = service.GetInterpolationForInterval(DateTime.Today, DateTime.Today, TimeSpan.FromDays(1), data);
            var enumerable = interpolations as Interpolation[] ?? interpolations.ToArray();
            Assert.Equal(1, enumerable.Count());
            Assert.Equal(10, enumerable.First().Value);
        }

        [Fact]
        public void GetInterpolation_IntervalBetweenTwoDates()
        {
            var service = new InterpolationService();
            var data = new List<Measurment>()
            {
                new Measurment { Date = DateTime.Today, Value = 10 },
                new Measurment { Date = DateTime.Today.AddDays(2), Value = 20 },

            };

            var interpolations = service.GetInterpolationForInterval(DateTime.Today, DateTime.Today.AddDays(2), TimeSpan.FromDays(1), data);
            var enumerable = interpolations as Interpolation[] ?? interpolations.ToArray();
            Assert.Collection(enumerable,
                _ => Assert.Equal(10, _.Value),
                _ => Assert.Equal(15, _.Value),
                _ => Assert.Equal(20, _.Value)
            );
        }
    }
}
