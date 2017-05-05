using homer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homer.Repositories
{
    public class TestInitialData
    {
        public static List<IMeasurmentType> MeasurmentTypes = new List<IMeasurmentType>
        {
            new MeasurmentType {Id=1, Name = "Gas" },
            new MeasurmentType { Id = 2, Name = "Water" },
            new MeasurmentType { Id = 3, Name = "Electricity" }
        };

        public static List<Measurment> Measurments = new List<Measurment> {
            new Measurment() { MeasurmentType = 1, Value = 10, Date = DateTime.Today.AddDays(-1), Id = 1 },
            new Measurment() { MeasurmentType = 1, Value = 11, Date = DateTime.Today.AddDays(-2), Id = 2 },
            new Measurment() { MeasurmentType = 1, Value = 12, Date = DateTime.Today.AddDays(-3), Id = 3 },
            new Measurment() { MeasurmentType = 2, Value = 13, Date = DateTime.Today.AddDays(-1), Id = 4 },
            new Measurment() { MeasurmentType = 2, Value = 15, Date = DateTime.Today.AddDays(-2), Id = 5 },
            new Measurment() { MeasurmentType = 2, Value = 16, Date = DateTime.Today.AddDays(-3), Id = 6 },
            new Measurment() { MeasurmentType = 3, Value = 18, Date = DateTime.Today.AddDays(-1), Id = 7 },
        };
    }
}
