
namespace homer.models
{
    public class Measurment: IIdentyfiable
    {
        public string Name {get; set;}
        public int Id { get; set; }
        public Measurment(string name)
        {
            Name = name;
        }
    } 
}