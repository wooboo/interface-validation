namespace WebApplication4.Models
{
    public class SomeCommand:INameModel, IValueModel
    {
        public string Name { get; set; }
        public int? Value { get; set; }
    }
}