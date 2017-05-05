using System;

namespace homer.models
{
    public interface IMeasurmentType: IIdentyfiable
    {
        string Name { get; set; }
    }

    public class MeasurmentType : IMeasurmentType
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}