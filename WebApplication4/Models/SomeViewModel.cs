namespace WebApplication4.Models
{
    public class SomeViewModel:INameModel, IValueModel
    {
        public string Name { get; set; }
        public int? Value { get; set; }
    }
    public class SomeOtherViewModel:INameModel, IValueModel
    {
        public string Name { get; set; }
        public int? Value { get; set; }
    }
}