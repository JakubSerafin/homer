
using System;

namespace homer.models
{
    public class Measurment : IIdentyfiable
    {
        public float Value { get; set; }
        public IMeasurmentType Type { get; set; }
        public int Id { get; set; }
        public Measurment()
        {
        }

        public DateTime Date {get; set;}
    } 
}