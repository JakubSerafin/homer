using homer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homer.Repositories
{
    public class TestInitialData
    {
        public static List<IMeasurmentType> MeasurmentTypes = new List<IMeasurmentType> { new MeasurmentType {Id=1, Name = "Gas" }, new MeasurmentType { Id = 2, Name = "Water" }, new MeasurmentType { Id = 3, Name = "Electricity" } };
        public static List<Measurment> Measurments = new List<Measurment> { new Measurment() { Type = MeasurmentTypes[1], Value = 10, Date = DateTime.Today.AddDays(-1), Id = 1 } };
    }
}
